using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.cloud.cognito.trigger.Models
{
    public class CustomMessageCallerContext
    {
        [JsonProperty("awsSdkVersion")]
        public string AwsSdkVersion { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }
    }
}
