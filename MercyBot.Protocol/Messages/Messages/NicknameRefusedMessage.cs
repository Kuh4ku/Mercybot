using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NicknameRefusedMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public NicknameRefusedMessage() { }

		public NicknameRefusedMessage(uint reason = 99)
		{
			Reason = reason;
		}

	}
}
