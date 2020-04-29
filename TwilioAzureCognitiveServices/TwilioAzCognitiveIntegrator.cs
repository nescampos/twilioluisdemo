using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML;

namespace TwilioAzureCognitiveServices
{
    public class TwilioAzCognitiveIntegrator
    {
        public MessagingResponse Response { get; set; }

        public TwilioAzCognitiveIntegrator(string data, string message, string LuisApiKey, string LuisUrlBase, string LuisAppId)
        {
            Response = GenerateResponse(data, message, LuisApiKey, LuisUrlBase, LuisAppId);
        }

        private MessagingResponse GenerateResponse(string data, string message, string LuisApiKey, string LuisUrlBase, string LuisAppId)
        {
            var messagingResponse = new MessagingResponse();
            var client = new HttpClient();
            var queryString = new NameValueCollection();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

            queryString["query"] = message;

            queryString["verbose"] = "true";
            queryString["show-all-intents"] = "false";
            queryString["staging"] = "false";
            queryString["timezoneOffset"] = "0";

            var endpointUri = String.Format("https://{0}/luis/prediction/v3.0/apps/{1}/slots/production/predict?{2}", LuisUrlBase, LuisAppId, queryString);

            var response = client.GetAsync(endpointUri).Result;

            var strResponseContent = response.Content.ReadAsStringAsync().Result;

            var respuesta = JsonConvert.DeserializeObject<LUISResponse>(strResponseContent);

            if (respuesta != null && respuesta.prediction != null)
            {
                IntentResponse intentResponse = new IntentResponse(data, respuesta.prediction.topIntent);
                if (intentResponse != null)
                {
                    if (respuesta.prediction.sentiment != null && respuesta.prediction.sentiment.label == "negative" && intentResponse.NegativeFeelingResponse != null)
                    {
                        foreach (var botRespuesta in intentResponse.NegativeFeelingResponse)
                        {
                            messagingResponse.Message(botRespuesta);
                        }
                    }
                    else
                    {
                        foreach (var botRespuesta in intentResponse.NormalFeelingResponse)
                        {
                            messagingResponse.Message(botRespuesta);
                        }
                    }
                }
                else
                {
                    messagingResponse.Message("Sorry, I don't have an answer loaded for your request.");
                }
            }
            else
            {
                messagingResponse.Message("Sorry, I had an internal error. I will fix it soon.");
            }
            return messagingResponse;
        }
    }
}
