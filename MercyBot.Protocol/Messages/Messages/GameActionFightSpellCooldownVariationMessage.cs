using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public uint SpellId { get; set; }
		public int Value { get; set; }


		// Constructors
		public GameActionFightSpellCooldownVariationMessage() { }

		public GameActionFightSpellCooldownVariationMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint spellId = 0, int value = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			SpellId = spellId;
			Value = value;
		}

	}
}
