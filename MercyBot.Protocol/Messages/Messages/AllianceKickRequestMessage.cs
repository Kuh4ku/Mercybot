using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceKickRequestMessage : Message
	{

		// Properties
		public uint KickedId { get; set; }


		// Constructors
		public AllianceKickRequestMessage() { }

		public AllianceKickRequestMessage(uint kickedId = 0)
		{
			KickedId = kickedId;
		}

	}
}
