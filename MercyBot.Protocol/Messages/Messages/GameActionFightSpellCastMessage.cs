using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
	{

		// Properties
		public uint SpellId { get; set; }
		public uint SpellLevel { get; set; }


		// Constructors
		public GameActionFightSpellCastMessage() { }

		public GameActionFightSpellCastMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int destinationCellId = 0, uint critical = 1, bool silentCast = false, uint spellId = 0, uint spellLevel = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			DestinationCellId = destinationCellId;
			Critical = critical;
			SilentCast = silentCast;
			SpellId = spellId;
			SpellLevel = spellLevel;
		}

	}
}
