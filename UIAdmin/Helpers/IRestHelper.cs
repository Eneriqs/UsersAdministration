using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAdmin.Helpers
{
    internal interface IRestHelper
    {
        #region Authenticate
        Task<Tuple<AuthenticateResponse, string>> Login(AuthenticateRequest authenticateRequest);
        #endregion

        #region Gets
        Task<Tuple<List<UserResponse>, string>> GetUsersBySyte(string site);
        Task<Tuple<List<UserInfo>, string>> GetUserByName(string userName);
        Task<Tuple<List<UserUniqueResponse>, string>> GetUniqUsersByName(string userName = "");
        Task<Tuple<List<string>, string>> GetSites(string siteName="");

        #endregion

        #region Alter 
        Task<Tuple<bool, string>> CreateUser(CreateUserRequest createUserRequest);
        Task<Tuple<bool, string>> AddSiteToUser(AddSiteToUserRequest addSiteToUserRequest);
        Task<Tuple<bool, string>> UpdateUser(UpdateUserRequest updateUserRequest);
        Task<Tuple<bool, string>> UpdatePassword(UpdatePasswordRequest updatePasswordRequest);
        Task<Tuple<bool, string>> DeleteUser(string userName);
        Task<Tuple<bool, string>> DeleteSiteForUser(string id, string site);
        #endregion
        #region Maintenances
        Task<Tuple<bool, string>> ExportDBToFile();
        Task<Tuple<bool, string>> ImportDBFromFile();
        #endregion
    }
}
