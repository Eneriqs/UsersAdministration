using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UpdateUserRequest
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "authName")]
        public string AuthName { get; set; }

        [JsonProperty(PropertyName = "appRole")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole AppRole { get; set; }
    }
}
