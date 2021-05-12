using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.cloud.cognito.trigger.Models
{
    public class CustomMessageBase
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("triggerSource")]
        public string TriggerSource { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("userPoolId")]
        public string UserPoolId { get; set; }

        [JsonProperty("callerContext")]
        public CustomMessageCallerContext CallerContext { get; set; }

        [JsonProperty("request")]
        public CustomMessageRequest Request { get; set; }

        [JsonProperty("response")]
        public CustomMessageResponse Response { get; set; }

        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        public JObject ToJson()
        {
            return JObject.FromObject(this);
        }
    }
}
