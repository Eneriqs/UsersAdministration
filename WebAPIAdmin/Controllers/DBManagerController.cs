using Microsoft.AspNetCore.Mvc;
using Common;
using WebAPIAdmin.Interfaces;
using WebAPIAdmin.Helpers;
using Common.Models;

namespace WebAPIAdmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBManagerController : ControllerBase
    {
        #region Members
        private readonly IDataService _dataService;
       
        private readonly ILogger<DBManagerController> _logger;
        #endregion
        #region Constructors
        public DBManagerController(ILogger<DBManagerController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = 
                dataService;
        }
        #endregion

        #region GET
        /// <summary>
        /// Get All sites or sites like name
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [Authorize]
         //GET: <UsersController>
        [HttpGet("Sites")]
        public async Task<IActionResult> GetSites( string? siteName)
        {
             return Ok(await _dataService.GetSites(siteName));
        }

        /// <summary>
        /// Get Users List for Site with equals parameter site
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetUsersBySite{site}")]
        public async Task<IActionResult> GetUsersBySite(string site)
        {
            return Ok(await _dataService.GetUsersBySite(site));
        }

        /// <summary>
        /// Get User with all Sites  for name or all users if parameter userName=null
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetUserByName{userName}")]
        public async Task<IActionResult> GetUserByName(string userName)
        {
            return Ok(await _dataService.GetUserByName(userName));
        }

        /// <summary>
        /// Get all Users like name 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetUsersInfoByName")]
        public async Task<IActionResult> GetUsersInfoByName(string? userName)
        {
            return Ok(await _dataService.GetUsersInfoByName(userName));
        }

        [HttpGet("GetUserInfoById{id}")]
        public async Task<IActionResult> GetUserInfoById(string id)
        {
            return Ok(await _dataService.GetUserInfoById(id));
        }

        [Authorize]
        [HttpGet("GetUniqUsersByName")]
        public async Task<IActionResult> GetUniqUsersByName(string? userName)
        {
            return Ok(await _dataService.GetUniqUsersByName(userName));
        }

        [Authorize]
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser(GetUserRequest getUserRequest)
        {
            _logger.LogInformation($"GetUser    ID : {getUserRequest.Id}");
            _logger.LogInformation($"           Site : {getUserRequest.Site}");
            return Ok(await _dataService.GetUser(getUserRequest));
        }

        #endregion
        #region Alter
        [Authorize]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            _logger.LogInformation($"CreateUser UserName : {userRequest.UserName}");
            _logger.LogInformation($"           AuthName : {userRequest.AuthName}");
            _logger.LogInformation($"           Site     : {userRequest.Site}");
            _logger.LogInformation($"           AppRole  : {userRequest.AppRole}");
            var res = await _dataService.CreateUser(userRequest);
            IActionResult response;
            switch (res.Item1){
                case 1: response = Ok(new Tuple<bool, string>(true,res.Item2)); break;
                case 0: response = BadRequest(new Tuple<bool, string>(false, res.Item2));break;
                default: response = Ok(new Tuple<bool, string>(false, res.Item2)); break;
            }
            return response ;
        }
        [Authorize]
        [HttpPost("AddSiteToUser")]
        public async Task<IActionResult> AddSiteToUser([FromBody] AddSiteToUserRequest addSiteToUserRequest)
        {
            _logger.LogInformation($"AddSiteToUser UserName: {addSiteToUserRequest.UserName}");
            _logger.LogInformation($"              Site    : {addSiteToUserRequest.Site}");          
            return Ok(await _dataService.AddSiteToUser(addSiteToUserRequest));
        }
        [Authorize]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest userRequest)
        {
            _logger.LogInformation($"UpdateUser UserName : {userRequest.UserName}");
            _logger.LogInformation($"           AuthName : {userRequest.AuthName}");
            _logger.LogInformation($"           Site     : {userRequest.Site}");
            _logger.LogInformation($"           AppRole  : {userRequest.AppRole}");
            var res = await _dataService.UpdateUser(userRequest);
            IActionResult response;
            switch (res.Item1)
            {
                case 1: response = Ok(new Tuple<bool, string>(true, res.Item2)); break;
                case 0: response = BadRequest(new Tuple<bool, string>(false, res.Item2)); break;
                default: response = Ok(new Tuple<bool, string>(false, res.Item2)); break;
            }
            return response;
        }
        [Authorize]
        //// DELETE <Controller>/5/TestSite
        [HttpDelete("{id}/{site}/{userName}")]
        public async Task<IActionResult> DeleteSiteForUser(string id, string site, string userName)
        {
            _logger.LogInformation($"DeleteSiteForUser UserName : {userName}");
            _logger.LogInformation($"           Site : {site}");

            return Ok(await _dataService.DeleteSiteForUser(id, site));
        }
        [Authorize]
        //// DELETE <Controller>/UserName
        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            return Ok(await _dataService.DeleteUser(userName));
        }
        [Authorize]
        ////[Authorize]
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest updatePasswordRequest)
        {
            Thread.Sleep(3000);
            _logger.LogInformation($"UpdatePassword UserName : {updatePasswordRequest.UserName}");
            _logger.LogInformation($"               AuthName : {updatePasswordRequest.AuthName}");
            return Ok(await _dataService.UpdatePassword(updatePasswordRequest));
        }
        #endregion
        #region Export/ Import DB
        [Authorize]
        [HttpGet("ExportDBToFile")]
        public async Task<IActionResult> ExportDBToFile()
        {
            return Ok(await _dataService.ExportDBToFile());
        }

        [Authorize]
        [HttpGet("ImportDBFromFile")]
        public async Task<IActionResult> ImportDBFromFile()
        {
            return Ok(await _dataService.ImportDBFromFile());
        }
        #endregion
    }
}