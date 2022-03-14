using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using WebAPIAdmin.Models;

namespace WebAPIAdmin.Helpers
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string sessionInfoStr = context.HttpContext.Session.GetString("UserSessionValue");
            if (!string.IsNullOrEmpty(sessionInfoStr)) { 
                var sessionInfo = JsonConvert.DeserializeObject<SessionInfo>(sessionInfoStr);
                if (sessionInfo?.Id != null && sessionInfo?.Token != null) 
                {
                    return;
                }
            }                
               // not logged in
             context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
           
        }
    }
}
