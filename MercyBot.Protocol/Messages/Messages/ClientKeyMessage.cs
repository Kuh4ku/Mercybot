using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ClientKeyMessage : Message
	{

		// Properties
		public string Key { get; set; }


		// Constructors
		public ClientKeyMessage() { }

		public ClientKeyMessage(string key = "")
		{
			Key = key;
		}

	}
}
