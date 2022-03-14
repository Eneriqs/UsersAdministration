using Common;
using Common.Models;

namespace WebAPIAdmin.Interfaces
{
    public interface IDataService
    {
        #region Authenticate
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest, string id);
        #endregion
        
        #region Read

        Task<List<UserResponse>> GetUsersBySite(string site);
        Task<UserInfo> GetUser(GetUserRequest userRequest);
        Task<List<UserInfo>> GetUserByName(string userName);

        Task<List<UserInfo>> GetUsersInfoByName(string? userName);
        Task<List<UserUniqueResponse>> GetUniqUsersByName(string? userName);
        Task<List<string>> GetSites(string siteName);
        
        Task<UserInfo> GetUserInfoById(string id);
        #endregion

        #region Alter
        Task<bool> CreateUser(CreateUserRequest userRequest);
        Task<bool> AddSiteToUser(AddSiteToUserRequest addSiteToUserRequest);
        Task<bool> UpdateUser(UpdateUserRequest userRequest);
        Task<bool> UpdatePassword(UpdatePasswordRequest updatePasswordRequest);
        Task<bool> DeleteUser(string userName);
        Task<bool> DeleteSiteForUser(string userId, string site);
        #endregion

        #region  Maintenance

        Task<bool> ExportDBToFile();
        Task<bool> ImportDBFromFile();
      
        #endregion


    }
}
