using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole
    {
        [EnumMember(Value = "System Manager")]
        SystemManager,
        [EnumMember(Value = "Operator")]
        Operator,
        [EnumMember(Value = "Building Manager")]
        BuildingManager       
    }

    public class UserInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "authPwrd")]
        public string AuthPwrd { get; set; }

        [JsonProperty(PropertyName = "authName")]
        public string AuthName { get; set; }

        [JsonProperty (PropertyName = "appRole")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole AppRole { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
   
}