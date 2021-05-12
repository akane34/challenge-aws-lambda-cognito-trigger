using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.cloud.cognito.trigger.Commons
{
    public static class Configuration
    {
        #region attributes
        private static string _queueUrl;
        private static string _accessKey;
        private static string _secretKey;
        private static string _userId;
        private static string _queueName;
        private static string _snsTopicArn;
        #endregion

        #region properties
        public static string SNS_TOPIC_ARN
        {
            get
            {
                if (_snsTopicArn == null)
                    _snsTopicArn = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SNS_TOPIC_ARN"))
                        ?
                        ""
                        :
                        Environment.GetEnvironmentVariable("SNS_TOPIC_ARN");
                return _snsTopicArn;
            }
        }
        #endregion
    }
}
