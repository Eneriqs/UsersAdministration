using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIAdmin.Interfaces
{
    public interface IFileService
    {
        Task SaveJSONAsync (List<UserInfo> users);
        Task<List<UserInfo>> GetUsersFromJSONAsync();
    }
}
