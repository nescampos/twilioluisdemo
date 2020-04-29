using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwilioAzureCognitiveServices
{
    public class LUISResponse
    {
        public string query { get; set; }
        public Prediction prediction { get; set; }


        public class Sentiment
        {
            public string label { get; set; }
            public double score { get; set; }
        }

        public class Prediction
        {
            public string topIntent { get; set; }
            public Sentiment sentiment { get; set; }
        }
    }
}