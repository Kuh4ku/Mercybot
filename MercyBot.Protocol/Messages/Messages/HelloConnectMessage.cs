using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HelloConnectMessage : Message
	{

		// Properties
		public List<int> Key { get; set; }
		public string Salt { get; set; }


		// Constructors
		public HelloConnectMessage() { }

		public HelloConnectMessage(string salt = "", List<int> key = null)
		{
			Salt = salt;
			Key = key;
		}

	}
}
