using System;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MiConsolaNetCore5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            TwilioClient.Init("AC8ad490527d2f6adab6f539a8121fab5e", "1271dab43d98be856b9a062bf043a6a3");

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+573175874548"));
            messageOptions.MessagingServiceSid = "MG1ef44b364f58f15fc9ac9fb0a3ece5df";
            messageOptions.Body = "Hello World! by ktsk console.";

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);


            Console.ReadLine();
        }
    }
}
