using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace TwilioAzureCognitiveServices.WebTest.Controllers
{
    public class MessageController : TwilioController
    {
        // GET: Message
        [HttpPost]
        public ActionResult Index(SmsRequest incomingMessage)
        {
            string data = System.IO.File.ReadAllText(Server.MapPath("~/Data/Responses.json"));
            TwilioAzCognitiveIntegrator twilioAzCognitiveIntegrator
                = new TwilioAzCognitiveIntegrator(data, incomingMessage.Body, ConfigurationManager.AppSettings["LUISApiKey"],
                ConfigurationManager.AppSettings["LUISUrl"], ConfigurationManager.AppSettings["LUISApiId"]);
            var messagingResponse = twilioAzCognitiveIntegrator.Response;

            return TwiML(messagingResponse);
        }
    }
}