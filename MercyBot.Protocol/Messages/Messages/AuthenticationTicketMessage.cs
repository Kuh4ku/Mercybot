using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AuthenticationTicketMessage : Message
	{

		// Properties
		public string Lang { get; set; }
		public string Ticket { get; set; }


		// Constructors
		public AuthenticationTicketMessage() { }

		public AuthenticationTicketMessage(string lang = "", string ticket = "")
		{
			Lang = lang;
			Ticket = ticket;
		}

	}
}
