using Amazon.CognitoIdentityProvider;
using Amazon.Lambda.Core;
using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.cloud.cognito.trigger.Models;

namespace challenge.cloud.cognito.trigger.Triggers
{
    public class CognitoCustomMessage
    {
        private readonly IAmazonCognitoIdentityProvider _cognitoIdentityProviderClient;

        //--- Constructors ---
        public CognitoCustomMessage()
        {
            _cognitoIdentityProviderClient = new AmazonCognitoIdentityProviderClient();
        }

        public CustomMessageBase FunctionHandler(CustomMessageBase cognitoCustomMessageEvent)
        {
            //LEVEL 4 - Add Custom Message Signup Workflow Trigger
            LambdaLogger.Log("LEVEL 4 - Add Custom Message Signup Workflow Trigger");

            return cognitoCustomMessageEvent;

        }
    }
}
