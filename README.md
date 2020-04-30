# twilioluisdemo
Example for connecting Twilio with LUIS (luis.ai) and using in Twilio for Whatsapp.

## About

This is a demo connecting LUIS.ai with Twilio for using Whatsapp, because there is no native connection between Azure Bot Framework/Service and Twilio for Whatsapp.
In this project, I extracted the necessary components to connect the Azure Language Understanding (LUIS) to use as a service and connect to Twilio using Webhook.
This project will be useful for all developers who have a chatbot developed with Bot Framework and need to use it with the WhatsApp channel with Twilio.
The implementation is with .NET Framework 4.6.1 and ASP.NET MVC and Twilio libraries from NuGET.

### How it works

This application works when you publish the Web application in a web server with public access.

## Features

- A library project (TwilioAzureCognitiveServices) with all classes for using in your project and connect the tools.
- A Web project for testing the library project and connect the services.

## Set up

### Requirements

- [LUIS.ai account](https://luis.ai/)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)

### First steps
1. Create an application in LUIS and train your model with intents, publish your luis app with sentiment analysis enabled in production slot.

## How to use it

1. Open the solution (.sln) in Visual Studio
2. Edit the file data\responses.json with your intents and their responses in NormalFeelingResponse field and NegativeFeelingResponse field (if you want your whatsapp bot have a response for negative questions).
3. Edit the web.config in web app (TwilioAzureCognitiveServices.WebTest), you must upload the LUISUrl key with your luis app region endpoint (for example: eastus.api.cognitive.microsoft.com), LUISAppId and LUISAppKey with your app data.
4. Build the web app (TwilioAzureCognitiveServices.WebTest). It's possible some libraries to be downloaded by Nuget.
5. Publish your web app in a public web server or cloud (Azure, AWS EC2, etc.)
6. Get the url of your app.
7. Add to the url of your app the following at end: /whatsapp/index
8. Copy your final URL (where your webservice is published) and paste it in your whatsapp sandbox (webhook message).


### Cloud deployment

You must have a Web server with support to .NET Framework version 4.6. It doesn't work locally because when you need the final URL and update your whatsapp sandbox in Twilio account.
 

## Contributing

This template is open source and welcomes contributions. 

## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com
[luis]: https://www.luis.ai
