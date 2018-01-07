using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NpcGenericActionRequestMessage : Message
	{

		// Properties
		public int NpcId { get; set; }
		public uint NpcActionId { get; set; }
		public int NpcMapId { get; set; }


		// Constructors
		public NpcGenericActionRequestMessage() { }

		public NpcGenericActionRequestMessage(int npcId = 0, uint npcActionId = 0, int npcMapId = 0)
		{
			NpcId = npcId;
			NpcActionId = npcActionId;
			NpcMapId = npcMapId;
		}

	}
}
