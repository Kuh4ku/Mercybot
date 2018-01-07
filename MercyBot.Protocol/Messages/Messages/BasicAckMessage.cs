using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicAckMessage : Message
	{

		// Properties
		public uint Seq { get; set; }
		public uint LastPacketId { get; set; }


		// Constructors
		public BasicAckMessage() { }

		public BasicAckMessage(uint seq = 0, uint lastPacketId = 0)
		{
			Seq = seq;
			LastPacketId = lastPacketId;
		}

	}
}
