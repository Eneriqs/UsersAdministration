using Common;
using Common.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIAdmin.Interfaces;
using WebAPIAdmin.Models;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Web;
using Microsoft.AspNetCore.Http;
using Serilog;
using Microsoft.Extensions.Logging;

namespace WebAPIAdmin.Services
{
    public class DataService : IDataService
    {
        #region Members
        private readonly IDBProvider _dbProvider;
        private readonly IFileService _fileService;
        private readonly LoginInfo _loginInfo;
        private static readonly Serilog.ILogger _logger = Log.ForContext<DataService>();
        #endregion
        #region Constructors
        public DataService( IDBProvider dbProvider,IFileService fileService,IConfiguration configuration )
        {
             _dbProvider = dbProvider; 
            _fileService = fileService;
            _loginInfo = configuration.GetSection("Settings:Login").Get<LoginInfo>(); ;
            _dbProvider.Connect();
            _dbProvider.GetDatabase();
            _dbProvider.GetContainer();
        }
        #endregion 
        #region Private Methods
        // helper methods
        private string generateJwtToken(string id)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_loginInfo.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
               // Issuer = "test",
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        #endregion
        #region Methods IDataService

        #region Authenticate
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest, string id)              
        {
             if (authenticateRequest == null || !authenticateRequest.UserName.Equals(_loginInfo.LoginName) 
                || !BCryptNet.Verify(authenticateRequest.Password, _loginInfo.Password)
              ){
                return null;
            }
       
             //authentication successful so generate jwt token
             var token = generateJwtToken(id);

            return new AuthenticateResponse(id, authenticateRequest.UserName, token);
        }
        #endregion

        #region Read
        public async Task<List<UserResponse>> GetUsersBySite(string site)
        {
            List<UserInfo> users = await _dbProvider.GetUsersBySiteAsync(site);
            return users.Select(x => new UserResponse()
            {
                AppRole = x.AppRole,
                AuthName = x.AuthName,
                Id = x.Id,
                UserName = x.UserName
            }).ToList();

        }
        public async Task<UserInfo> GetUser(GetUserRequest userRequest)
        {
            return await _dbProvider.GetUserInfoByIdAsync(userRequest.Id, userRequest.Site);
        }

        /// <summary>
        ///  Get User with all Sites  for name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<List<UserInfo>> GetUserByName(string userName)
        {
            return  await _dbProvider.GetUserByNameAsync(userName);            
        }
        public async Task<List<UserInfo>> GetUsersInfoByName(string? userName) 
        { 
          return  await _dbProvider.GetUsersLikeByNameAsync(userName);    
        }
        public async Task<List<UserUniqueResponse>> GetUniqUsersByName(string? userName)
        {
            List<UserInfo> users = await _dbProvider.GetUniqueUsersByNameAsync(userName);
            return users.Select(x => new UserUniqueResponse()
            {
                AppRole = x.AppRole,
                AuthName = x.AuthName,
                UserName = x.UserName
            }).ToList();
        }
        public async Task<List<string>> GetSites(string siteName)
        {
            List<UserInfo> users = await _dbProvider.GetSitesAsync(siteName);
            return users.Select(x => x.Site).ToList();           
        }
        public async Task<UserInfo> GetUserInfoById(string id)
        {
            return await _dbProvider.GetUserInfoByIdAsync(id);
        }
        #endregion

        #region Alter

        public async Task<bool> CreateUser(CreateUserRequest userRequest)
        {
            UserInfo user = new UserInfo()
            {
                UserName = userRequest.UserName,
                Site = userRequest.Site,
                AppRole = userRequest.AppRole,
                AuthName = userRequest.AuthName,
                AuthPwrd = userRequest.AuthPwrd,
                Id = Guid.NewGuid().ToString(),
            };
            return await _dbProvider.AddItemsToContainerAsync(user);
        }

        public async Task<bool> AddSiteToUser(AddSiteToUserRequest addSiteToUserRequest)
        {
            return await _dbProvider.AddSiteToUser(addSiteToUserRequest);
        }

        public async Task<bool> UpdateUser(UpdateUserRequest userRequest)
        {
            UserInfo user = new UserInfo()
            {
                UserName = userRequest.UserName,
                Site = userRequest.Site,
                AppRole = userRequest.AppRole,
                AuthName = userRequest.AuthName,
                Id = userRequest.Id
            };
            return await _dbProvider.UpdateItemAsync(user);
        }
        public async Task<bool> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        {
            return await _dbProvider.UpdatePasswordAsync(updatePasswordRequest);
        }

        public async Task<bool> DeleteUser(string userName)
        {
            return await _dbProvider.DeleteUserAsync(userName);
        }

        public async Task<bool> DeleteSiteForUser(string userId, string site) {
            return await _dbProvider.DeleteItemAsync(userId, site);
        }
        #endregion

        #region Maintenance
        public async Task<bool> ExportDBToFile()
        {
            List<UserInfo> users = await _dbProvider.GetUsersLikeByNameAsync();
            try
            {
                await _fileService.SaveJSONAsync(users);
            }catch (Exception ex)
            {
                _logger.Error("Problem SaveJSONAsync", ex.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> ImportDBFromFile()
        {
            List<UserInfo> users = await _fileService.GetUsersFromJSONAsync();
            if (users != null)
            {
                return await _dbProvider.InsertNotExistsItemsAsync(users);
            }
            return false;
            
        }     

        #endregion

        #endregion

    }
}
