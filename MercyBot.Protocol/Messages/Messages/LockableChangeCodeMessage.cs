using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LockableChangeCodeMessage : Message
	{

		// Properties
		public string Code { get; set; }


		// Constructors
		public LockableChangeCodeMessage() { }

		public LockableChangeCodeMessage(string code = "")
		{
			Code = code;
		}

	}
}
