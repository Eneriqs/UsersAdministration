using Common;
using Common.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Serilog;
using WebAPIAdmin.Interfaces;
using WebAPIAdmin.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebAPIAdmin.Services
{
    public class CosmosProvider : IDBProvider
    {
        #region Members

        private DBInfo _dbInfo;
        private CosmosClient _cosmosClient;       
        private Database _database;     
        private Container _container;
        private static readonly Serilog.ILogger _logger = Log.ForContext<CosmosProvider>();
        #endregion

        #region Constructors

        public CosmosProvider(IConfiguration configuration)
        {
            _dbInfo = configuration.GetSection("Settings:DB").Get<DBInfo>();          
        }

        #endregion

        #region Private Methods
        // <QueryItemsAsync>
        /// <summary>
        /// Run a query (using Azure Cosmos DB SQL syntax) against the container
        /// </summary>
        private async Task<List<UserInfo>> QueryItemsWhereAsync(string select,  string where)
        {
            select = string.IsNullOrEmpty(select) ? "SELECT * FROM c" : select;
            var sqlQueryText = string.IsNullOrEmpty(where) ? select : $"{select} Where {where}" ;
                      
            List<UserInfo> users = new List<UserInfo>();
         
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<UserInfo> queryResultSetIterator = this._container.GetItemQueryIterator<UserInfo>(queryDefinition);
            try
            {
                while (queryResultSetIterator.HasMoreResults)
                {
                    var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (UserInfo user in currentResultSet)
                    {
                        users.Add(user);
                    }
                }
            }catch (Exception ex)
            {
                _logger.Error($" Problem {sqlQueryText}", ex.Message);
            }
            
            return users;

        }

        private async Task<List<UserInfo>> GetUserByNameOrAuthNameAsync(string userName, string authName)
        {
            string queryText = $"LOWER(c.userName) = '{userName.ToLower()}' OR LOWER(c.authName) = '{authName.ToLower()}'";
            return await this.QueryItemsWhereAsync("", queryText);
        }

        private async Task<bool> CheckIfExistsUser(string userName, string authName)
        {
            var usersWithNewName = await this.GetUserByNameOrAuthNameAsync(userName, authName);
            return (usersWithNewName != null && usersWithNewName.Count > 0);
            
        }

        private async Task<bool> CheckIfExistsEnotherUserWithName(string userName, string authName, string id)
        {
            var usersWithNewName = await this.GetUserByNameOrAuthNameAsync(userName, authName);
            return usersWithNewName != null && usersWithNewName.Any(x=>x.Id != id);
        }


        private async Task<bool> CreateNewUser(UserInfo user)
        {
            try
            {
                ItemResponse<UserInfo> itemResponse = await this._container.CreateItemAsync<UserInfo>(user, new PartitionKey(user.Site));
                return true;
            }
            catch (Exception ex) 
            {
                _logger.Error("Problem CreateNewUser", ex.Message);
                return false;
            }
            
        }
        #endregion

        #region IDBProvider

        #region DB and Container
        public void Connect()
        {
            this._cosmosClient = new CosmosClient(_dbInfo.EndpointUri, _dbInfo.PrimaryKey);
        }

        public void GetContainer()
        {
            this._container =  this._database.GetContainer(_dbInfo.ContainerId);
        }

        public void GetDatabase()
        {
           this._database =  this._cosmosClient.GetDatabase(_dbInfo.DatabaseId); ;
        }
        #endregion                

        #region Authenticate
        public async Task<UserInfo> Authenticate(AuthenticateRequest authenticateRequest, string loginRole)
        {
            var users = await this.QueryItemsWhereAsync("", $"c.authName = '{authenticateRequest.UserName.Trim()}' AND c.appRole = '{loginRole}'");

            // verify password
            if (users == null || users.Count == 0 || !BCryptNet.Verify(authenticateRequest.Password, users[0].AuthPwrd))
               return null;

            return users[0];
        }
        #endregion

        #region  Select
        public async Task<List<UserInfo>> GetSitesAsync(string siteName = "")
        {
            string queryText = string.IsNullOrEmpty(siteName) ? "" : $"CONTAINS( LOWER(c.site) , '{siteName.ToLower()}')";
            return await this.QueryItemsWhereAsync( "SELECT distinct c.site FROM c  ", queryText);
        }

        public async Task<List<UserInfo>> GetUserByNameAsync(string userName)
        {
            string queryText = $"LOWER(c.userName) = '{userName.ToLower()}'";
            return await this.QueryItemsWhereAsync("", queryText);
        }      

        public async Task<List<UserInfo>> GetUsersLikeByNameAsync(string? userName = "") {
            string queryText = string.IsNullOrEmpty(userName) ? "": $"CONTAINS( LOWER(c.userName) , '{userName.ToLower()}')";
            return await this.QueryItemsWhereAsync("", queryText);

        }
        public async Task<List<UserInfo>> GetUniqueUsersByNameAsync(string? userName = "")
        {
            string queryText = string.IsNullOrEmpty(userName) ? "" : $"CONTAINS( LOWER(c.userName) , '{userName.ToLower()}')";
            return await this.QueryItemsWhereAsync("SELECT distinct c.userName, c.authName, c.appRole  FROM c ", queryText);
        }

        public async Task<List<UserInfo>> GetUsersBySiteAsync(string site)
        {
            return await this.QueryItemsWhereAsync("", $"c.site = '{site}'");
        }

        public async Task<UserInfo> GetUserInfoByIdAsync(string id, string site= "")
        {
            string whereId = $"c.id = '{id}'";
            string queryText = string.IsNullOrEmpty(site)?  whereId : $" {whereId} and c.site = '{site}'";
            return (await this.QueryItemsWhereAsync("", queryText)).FirstOrDefault();
        }
       
        #endregion

        #region Alter

        public async Task<Tuple<int, string>> AddItemsToContainerAsync(UserInfo user)
        {
            if (await this.CheckIfExistsUser(user.UserName,  user.AuthName))
            {
                _logger.Warning($" User {user.UserName} or {user.AuthName} already exists");
                return new Tuple<int, string> (0, "User already exits");
            }
            user.AuthPwrd = BCryptNet.HashPassword(user.AuthPwrd);
            return (await CreateNewUser(user)) ? new Tuple<int, string>(1, "") : new Tuple<int, string>(-1, "Create user failure");
            
        }    

        public async Task<bool> AddSiteToUser(AddSiteToUserRequest addSiteToUserRequest)
        {
            List<UserInfo> userSites = await this.GetUserByNameAsync(addSiteToUserRequest.UserName);
            if (userSites==null || userSites.Count()==0 ||  userSites.Any(x => x.Site.Equals(addSiteToUserRequest.Site))) 
            {
                _logger.Warning($" Site {addSiteToUserRequest.Site} already exists or user {addSiteToUserRequest.UserName} does not exists");
                return false;
            }
            UserInfo userToInsert = userSites[0];
            userToInsert.Id = Guid.NewGuid().ToString() ;
            userToInsert.Site = addSiteToUserRequest.Site;

            return await CreateNewUser(userToInsert);         
        }

        public async Task<bool> DeleteItemAsync(string id, string site)
        {
            // Delete an item. Note we must provide the partition key value and id of the item to delete
            try
            {
                ItemResponse<UserInfo> deleteResponse = await this._container.DeleteItemAsync<UserInfo>(id,  new PartitionKey(site));
            }
            catch (Exception ex)
            {
                _logger.Error($"DeleteItem Problem id:{id} site:{site}", ex.Message);
                return false;
            }
             return true;
        }

        public async Task<bool> DeleteUserAsync(string userName) {

            List<UserInfo> users = await GetUserByNameAsync(userName);
            bool result = true;
            foreach (UserInfo item in users)
            {
                try
                { 
                    await this.DeleteItemAsync(item.Id, item.Site);
                }
                catch (Exception ex)
                {
                    _logger.Error($"DeleteItem Problem id:{item.Id} site:{item.Site}", ex.Message);
                    result = false;
                }               
            }
            return result;

        }
        public async Task<Tuple<int, string>> UpdateItemAsync(UserInfo user)
        {
            UserInfo userOld = await this.GetUserInfoByIdAsync(user.Id, user.Site);
            if (userOld ==  null )
            {
                _logger.Warning($"User {user.Id} site {user.Site} is not exists");
                return new Tuple<int, string>(0,"User is not exits");
            }
            if ((userOld.UserName != user.UserName || userOld.AuthName != user.AuthName ) && await this.CheckIfExistsEnotherUserWithName(user.UserName, user.AuthName, user.Id))
            {
                _logger.Warning($" User with name {user.UserName} or login {user.AuthName} already exists");
                //User with name already exists
                return new Tuple<int, string>(0, "User already exits");
                
            }
            bool result = true;
            List<UserInfo> users = await this.QueryItemsWhereAsync("", $"c.userName = '{userOld.UserName}' AND c.authName='{userOld.AuthName}'");
            foreach ( UserInfo item  in users)
            {
                item.AuthName = user.AuthName;
                item.AppRole = user.AppRole;
                item.UserName = user.UserName;
                try
                {
                    var updateResponse = await this._container.ReplaceItemAsync<UserInfo>(item, item.Id, new PartitionKey(item.Site));
                }
                catch (Exception ex) 
                { 
                    result = false;
                    _logger.Error( $"update item id {item.Id} site {item.Site}", ex.Message);
                }
              
            }
            return  (result) ? new Tuple<int, string>(1,""): new Tuple<int, string>(-1, "Update user failure");
        }

        public async Task<bool> InsertNotExistsItemsAsync(List<UserInfo> users)
        {
            bool result = true;
            foreach(UserInfo user in users)
            {
                if (await this.GetUserInfoByIdAsync(user.Id, user.Site) == null) {
                    if (!await CreateNewUser(user))
                    {
                        result = false;
                    }
                }
            }
            
            return result;
        }

        public async Task<bool> UpdatePasswordAsync(UpdatePasswordRequest updatePasswordRequest)
        {
            List<UserInfo> users = await this.QueryItemsWhereAsync("", $"c.userName = '{updatePasswordRequest.UserName}' AND c.authName='{updatePasswordRequest.AuthName}'");
            string password = BCryptNet.HashPassword(updatePasswordRequest.Password);
            foreach (UserInfo item in users)
            {
                item.AuthPwrd = password;
                try
                {
                    var updateResponse = await this._container.ReplaceItemAsync<UserInfo>(item, item.Id, new PartitionKey(item.Site));
                }catch (Exception ex)
                {
                    _logger.Error($"Problem update  password item id {item.Id} site {item.Site}", ex.Message);
                    return false;
                }               
            }
            return true;
        }

        #endregion

        #endregion

    }

}
