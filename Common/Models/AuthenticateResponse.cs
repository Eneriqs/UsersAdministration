using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AuthenticateResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
                     
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        
        public AuthenticateResponse() { 
        
        }

        public AuthenticateResponse(string id, string userName, string token)
        {
            Id = id;
            UserName =userName;
            Token = token;
        }
    }
}
