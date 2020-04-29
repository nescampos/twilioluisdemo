using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TwilioAzureCognitiveServices
{
    public class IntentResponse
    {
        public string[] NormalFeelingResponse { get; set; }
        public string[] NegativeFeelingResponse { get; set; }


        public IntentResponse(string data, string topIntent)
        {
            //;
            var respuesta = JsonConvert.DeserializeObject<Responses>(data);
            if(respuesta != null && respuesta.responses != null && respuesta.responses.Any(x => x.intent == topIntent))
            {
                NormalFeelingResponse = respuesta.responses.FirstOrDefault(x => x.intent == topIntent).NormalFeelingResponse;
                NegativeFeelingResponse = respuesta.responses.FirstOrDefault(x => x.intent == topIntent).NegativeFeelingResponse;
            }
        }


        private class Responses
        {
            public DataResponse[] responses { get; set; }
        }

        private class DataResponse
        {
            public string intent { get; set; }
            public string[] NormalFeelingResponse { get; set; }
            public string[] NegativeFeelingResponse { get; set; }
        }

    }
}