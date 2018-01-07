using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountEmoteIconUsedOkMessage : Message
	{

		// Properties
		public int MountId { get; set; }
		public uint ReactionType { get; set; }


		// Constructors
		public MountEmoteIconUsedOkMessage() { }

		public MountEmoteIconUsedOkMessage(int mountId = 0, uint reactionType = 0)
		{
			MountId = mountId;
			ReactionType = reactionType;
		}

	}
}
