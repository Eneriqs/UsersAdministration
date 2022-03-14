using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPIAdmin.Interfaces;
using WebAPIAdmin.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIAdmin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDataService _dataService;

        private readonly ILogger<DBManagerController> _logger;
       

        public LoginController(ILogger<DBManagerController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;        
        }

        // GET: <AuthenticateController>
        [HttpGet("Authenticate")]
        public IActionResult Authenticate([FromQuery] AuthenticateRequest authenticateRequest)
        {
            string id = new Random().Next(1000).ToString();           
            var response =  _dataService.Authenticate(authenticateRequest,id).Result;
            if (response == null)
              return BadRequest(new { message = "Username or password is incorrect" });
            SessionInfo info = new SessionInfo()
            {
                Id = id
            };
            string session = JsonConvert.SerializeObject(info);
            HttpContext.Session.SetString("UserSessionValue",session);
            return Ok(response);           
        }
    }
}
