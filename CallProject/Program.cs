using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CallProject
{
	class Program
	{
		static void Main(string[] args)
		{
			string accountSid;
			string authToken;

			bool loggedIn = false;

			while (!loggedIn)
			{
				Console.WriteLine("Account SID: ");
				accountSid = Console.ReadLine();

				Console.WriteLine("Auth Token: ");
				authToken = Console.ReadLine();

				try
				{
					TwilioClient.Init(accountSid, authToken);
					loggedIn = true;
					Console.WriteLine("Logged in! Press any button to proceed!");
				}
				catch (Exception e)
				{
					Console.Write(e);
					throw;
				}
			}
			Console.ReadKey();
			
			Console.Clear();
			Console.WriteLine("Number to be called: ");
			string numberToCall = Console.ReadLine();
			
			var to = new PhoneNumber(numberToCall);
			
			//either get from twilio via http or hardcode!
			var from = new PhoneNumber("");

			var call = CallResource.Create(to, from, url: new Uri($@"..\..\Messages\Text.xml"));

			Console.WriteLine(call.Status);

		}

		
	}
}
