using Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPIAdmin.Interfaces;

namespace WebAPIAdmin.Services
{
    public class FileService : IFileService
    {
        #region Members
        private string _outputPath;
        private static readonly Serilog.ILogger _logger = Log.ForContext<FileService>();
        #endregion
        #region Constructors       

        public FileService(IConfiguration configuration)
        {
            _outputPath = configuration.GetValue<string>("Settings:OutputPath");
        }
        #endregion
        #region IFileService
        public Task SaveJSONAsync (List<UserInfo> users)
        {
            
            return File.WriteAllTextAsync(_outputPath, JsonConvert.SerializeObject(users));
        }
        public async Task<List<UserInfo>> GetUsersFromJSONAsync()
        {
            var usersData = await File.ReadAllTextAsync(_outputPath);
            List<UserInfo>? users = null;
            try 
            {
                users = JsonConvert.DeserializeObject<List<UserInfo>>(usersData);               
            } 
            catch(Exception ex)
            {
                _logger.Error($"Deserialization Problem {usersData}");
            }
            return users;
        }
        #endregion
    }
}
