using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIAdmin.Interfaces
{
    public interface IDBProvider
    {
        #region  DB and Container

        void Connect();
        void GetDatabase();
        void GetContainer();
        #endregion

        #region Authenticate
        Task<UserInfo> Authenticate(AuthenticateRequest authenticateRequest, string loginRole);
        #endregion

        #region Select
        Task<List<UserInfo>> GetSitesAsync(string siteName = "");
        Task<List<UserInfo>> GetUserByNameAsync(string userName);
        Task<List<UserInfo>> GetUsersLikeByNameAsync(string? userName = "");
        Task<List<UserInfo>> GetUniqueUsersByNameAsync(string? userName = "");
        Task<List<UserInfo>> GetUsersBySiteAsync(string site);
        Task<UserInfo> GetUserInfoByIdAsync(string id, string site="");

        #endregion

        #region Alter
        Task<Tuple<int, string>> AddItemsToContainerAsync(UserInfo user);
        Task<bool> AddSiteToUser(AddSiteToUserRequest addSiteToUserRequest);
        Task<bool> DeleteItemAsync(string id, string site);
        Task<bool> DeleteUserAsync(string userName);
        Task<Tuple<int, string>> UpdateItemAsync(UserInfo user);
        Task<bool> InsertNotExistsItemsAsync(List<UserInfo> users);
        Task<bool> UpdatePasswordAsync(UpdatePasswordRequest updatePasswordRequest);
      
        #endregion


    }
}
