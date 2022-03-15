using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAdmin.Helpers
{
    internal enum ViewAlter { 
        ChangePassword,
        CreateUser,
        UpdateUser,
        AddSiteToUser,
        NewSiteToUser,
        AddUserToSite
    }

    internal enum TypeAlter
    {
        Site,
        User,
        Empty,
        SiteUser,
        UserOnlySiteList,
        SyteOnlyUserList
    }

    internal static class ProjectConstance
    {
        public const string Authenticate = "Login/Authenticate";
        public const string Sites = "DBManager/Sites";
        public const string GetUsersBySite= "DBManager/GetUsersBySite";
        public const string GetUserByName = "DBManager/GetUserByName";
        public const string GetUniqUsersByName = "DBManager/GetUniqUsersByName";
        public const string GetUserInfoById  = "DBManager/GetUserInfoById";
        public const string UpdatePassword = "DBManager/UpdatePassword";
        public const string CreateUser = "DBManager/CreateUser";
        public const string AddSiteToUser= "DBManager/AddSiteToUser";
        public const string UpdateUser = "DBManager/UpdateUser";
        public const string DeleteUser = "DbManager";
        public const string ExportDBToFile = "DBManager/ExportDBToFile";
        public const string ImportDBFromFile = "DBManager/ImportDBFromFile";



    }
}
