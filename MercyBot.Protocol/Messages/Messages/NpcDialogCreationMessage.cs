using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NpcDialogCreationMessage : Message
	{

		// Properties
		public int MapId { get; set; }
		public int NpcId { get; set; }


		// Constructors
		public NpcDialogCreationMessage() { }

		public NpcDialogCreationMessage(int mapId = 0, int npcId = 0)
		{
			MapId = mapId;
			NpcId = npcId;
		}

	}
}
