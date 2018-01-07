using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
	{

		// Properties
		public int MarkId { get; set; }
		public int TriggeringCharacterId { get; set; }
		public uint TriggeredSpellId { get; set; }


		// Constructors
		public GameActionFightTriggerGlyphTrapMessage() { }

		public GameActionFightTriggerGlyphTrapMessage(uint actionId = 0, int sourceId = 0, int markId = 0, int triggeringCharacterId = 0, uint triggeredSpellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			MarkId = markId;
			TriggeringCharacterId = triggeringCharacterId;
			TriggeredSpellId = triggeredSpellId;
		}

	}
}
