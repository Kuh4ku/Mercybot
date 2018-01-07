using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightCastRequestMessage : Message
	{

		// Properties
		public uint SpellId { get; set; }
		public int CellId { get; set; }


		// Constructors
		public GameActionFightCastRequestMessage() { }

		public GameActionFightCastRequestMessage(uint spellId = 0, int cellId = 0)
		{
			SpellId = spellId;
			CellId = cellId;
		}

	}
}
