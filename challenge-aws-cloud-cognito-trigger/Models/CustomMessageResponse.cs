using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.cloud.cognito.trigger.Models
{
    public class CustomMessageResponse
    {
        [JsonProperty("smsMessage")]
        public string SmsMessage { get; set; }

        [JsonProperty("emailMessage")]
        public string EmailMessage { get; set; }

        [JsonProperty("emailSubject")]
        public string EmailSubject { get; set; }
    }
}
