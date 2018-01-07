using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportOnSameMapMessage : Message
	{

		// Properties
		public int TargetId { get; set; }
		public uint CellId { get; set; }


		// Constructors
		public TeleportOnSameMapMessage() { }

		public TeleportOnSameMapMessage(int targetId = 0, uint cellId = 0)
		{
			TargetId = targetId;
			CellId = cellId;
		}

	}
}
