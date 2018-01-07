using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LockableUseCodeMessage : Message
	{

		// Properties
		public string Code { get; set; }


		// Constructors
		public LockableUseCodeMessage() { }

		public LockableUseCodeMessage(string code = "")
		{
			Code = code;
		}

	}
}
