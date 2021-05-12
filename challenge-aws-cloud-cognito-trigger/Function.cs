using Amazon.Lambda.Core;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using challenge.cloud.cognito.trigger.Commons;
using challenge.cloud.cognito.trigger.Models;
using challenge.cloud.cognito.trigger.Triggers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace challenge.cloud.cognito.trigger
{
    public class Function
    {
        public async Task<JObject> FunctionHandler(JObject cognitoTriggerEvent, ILambdaContext context)
        {
            try
            {                
                CustomMessageBase eventMessage = JsonConvert.DeserializeObject<CustomMessageBase>(JsonConvert.SerializeObject(cognitoTriggerEvent));

                LambdaLogger.Log(eventMessage.ToJson().ToString());

                switch (eventMessage.TriggerSource)
                {                    
                    case "PostConfirmation_ConfirmSignUp":
                        
                        var name = eventMessage.Request.UserAttributes["name"];
                        var familyName = eventMessage.Request.UserAttributes["family_name"];
                        var email = eventMessage.Request.UserAttributes["email"];
                        var message = $"{{ 'name' : '{name}', 'familyName':'{familyName}', 'email':'{email}' }}";

                        /*var sendRequest = new SendMessageRequest();
                        sendRequest.QueueUrl = Configuration.QUEUE_URL;
                        sendRequest.MessageBody = message;

                        var amazonSQSClient = new AmazonSQSClient();
                        var response = await amazonSQSClient.SendMessageAsync(sendRequest);*/

                        var snsClient = new AmazonSimpleNotificationServiceClient();
                        var request = new PublishRequest
                        {
                            TopicArn = Configuration.SNS_TOPIC_ARN,
                            Message = message
                        };

                        var response = await snsClient.PublishAsync(request);

                        LambdaLogger.Log(message);
                        LambdaLogger.Log(JsonConvert.SerializeObject(response));

                        break;
                    default:                        
                        LambdaLogger.Log($"No custom implementations for: {eventMessage.TriggerSource}");
                        break;
                }
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($"Error: {ex.Message}");
            }
            return cognitoTriggerEvent;
        }
    }
}
