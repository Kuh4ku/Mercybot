using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterTransferMessage : Message
	{

		// Properties
		public string Uid { get; set; }
		public uint Failure { get; set; }


		// Constructors
		public KrosmasterTransferMessage() { }

		public KrosmasterTransferMessage(string uid = "", uint failure = 0)
		{
			Uid = uid;
			Failure = failure;
		}

	}
}
