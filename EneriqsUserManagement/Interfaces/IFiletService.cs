using Common;

namespace WebAPIAdmin.Interfaces
{
    public interface IFileService
    {
        Task SaveJSONAsync (List<UserInfo> users);
        Task<List<UserInfo>> GetUsersFromJSONAsync();
    }
}
