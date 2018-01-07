using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
	{

		// Properties
		public uint SpellId { get; set; }


		// Constructors
		public GameActionFightDispellSpellMessage() { }

		public GameActionFightDispellSpellMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint spellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			SpellId = spellId;
		}

	}
}
