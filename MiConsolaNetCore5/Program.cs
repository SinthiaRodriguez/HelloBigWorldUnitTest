using System;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Mime;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace MiConsolaNetCore5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //PruebaTwilio();
            //PruebaCrearCasoSalesForce();
            PruebaCodigoAleatorio();

            Console.ReadLine();
        }

        private static void PruebaCrearCasoSalesForce()
        {
            var client = new RestClient("https://grantitan.my.salesforce.com/services/data/v52.0/sobjects/Case");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer 00D5Y000001cIob!ASAAQPpb1dq0LxdiRsiSdgmRlMksmAeEzKx6lTBlYabpFtdldXBd6UIkzd72nLbPOrt4GaPtAjWdqEYZasEKnkkN_JCf0f0G");
            //request.AddHeader("Cookie", "BrowserId=K4EM4-A4Eeu6JcX6BudT5Q; CookieConsentPolicy=0:0");
            var body = @"{" + "\n" +
            @"    ""Comments"": ""prueba desde codigo de consola 2""," + "\n" +
            @"    ""Subject"" : ""Reestablecer contraseña system""," + "\n" +
            @"    ""SuppliedEmail"": ""sinthiak.rodriguezv@utadeo.edu.co""" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static void PruebaTwilio()
        {
            TwilioClient.Init("AC8ad490527d2f6adab6f539a8121fab5e", "1271dab43d98be856b9a062bf043a6a3");

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+573175874548"));
            messageOptions.MessagingServiceSid = "MG1ef44b364f58f15fc9ac9fb0a3ece5df";
            messageOptions.Body = "Hello World! by ktsk console.";

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }

        private static void PruebaCodigoAleatorio() 
        {
            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            Console.WriteLine(token.Substring(0, longitud));



        }
    }
}
