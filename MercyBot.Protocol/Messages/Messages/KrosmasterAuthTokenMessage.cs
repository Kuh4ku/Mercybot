using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterAuthTokenMessage : Message
	{

		// Properties
		public string Token { get; set; }


		// Constructors
		public KrosmasterAuthTokenMessage() { }

		public KrosmasterAuthTokenMessage(string token = "")
		{
			Token = token;
		}

	}
}
