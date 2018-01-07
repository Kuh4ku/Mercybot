using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterTransferRequestMessage : Message
	{

		// Properties
		public string Uid { get; set; }


		// Constructors
		public KrosmasterTransferRequestMessage() { }

		public KrosmasterTransferRequestMessage(string uid = "")
		{
			Uid = uid;
		}

	}
}
