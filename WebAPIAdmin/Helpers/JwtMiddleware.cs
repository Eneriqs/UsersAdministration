
namespace WebAPIAdmin.Helpers
{
    using Common.Models;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Serilog;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using WebAPIAdmin.Controllers;
    using WebAPIAdmin.Interfaces;
    using WebAPIAdmin.Models;

    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;
        private static readonly Serilog.ILogger _logger = Log.ForContext<JwtMiddleware>();
        public JwtMiddleware(RequestDelegate next, string secret)
        {
            _next = next;
            _secret = secret;

        }

        public async Task Invoke(HttpContext context, ILogger<DBManagerController> logger, IDataService dataService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachUserToContext(context,dataService, token);
            }             

            
            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, IDataService dataService, string token)
        {
            try
            {
                var t = context.Session.GetString("UserSessionValue");
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                string info = context.Session.GetString("UserSessionValue");
                string session = string.Empty;
                if (info != null)
                {
                    SessionInfo sessionInfo= JsonConvert.DeserializeObject<SessionInfo>(info);
                    if (userId == sessionInfo?.Id)
                    {
                        sessionInfo.Token = jwtToken.ToString();
                    }
                    session = JsonConvert.SerializeObject(sessionInfo);                  

                }  
                context.Session.SetString("UserSessionValue", session);
              
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
                context.Session.SetString("UserSessionValue", string.Empty);
                _logger.Error("Problem JWT attachUserToContext. User is not attached to context");
            }
        }
    }
}
