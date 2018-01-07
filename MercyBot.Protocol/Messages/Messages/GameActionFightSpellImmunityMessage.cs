using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightSpellImmunityMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public uint SpellId { get; set; }


		// Constructors
		public GameActionFightSpellImmunityMessage() { }

		public GameActionFightSpellImmunityMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint spellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			SpellId = spellId;
		}

	}
}
