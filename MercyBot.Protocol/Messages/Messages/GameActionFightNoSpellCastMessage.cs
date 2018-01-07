using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightNoSpellCastMessage : Message
	{

		// Properties
		public uint SpellLevelId { get; set; }


		// Constructors
		public GameActionFightNoSpellCastMessage() { }

		public GameActionFightNoSpellCastMessage(uint spellLevelId = 0)
		{
			SpellLevelId = spellLevelId;
		}

	}
}
