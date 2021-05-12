using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.cloud.cognito.trigger.Models
{
    public class CustomMessageRequest
    {
        [JsonProperty("userAttributes")]
        public Dictionary<string, string> UserAttributes { get; set; }

        [JsonProperty("codeParameter")]
        public string CodeParameter { get; set; }

        [JsonProperty("usernameParameter")]
        public string usernameParameter { get; set; }
    }
}
