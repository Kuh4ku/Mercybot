using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonKeyRingMessage : Message
	{

		// Properties
		public List<uint> Availables { get; set; }
		public List<uint> Unavailables { get; set; }


		// Constructors
		public DungeonKeyRingMessage() { }

		public DungeonKeyRingMessage(List<uint> availables = null, List<uint> unavailables = null)
		{
			Availables = availables;
			Unavailables = unavailables;
		}

	}
}
