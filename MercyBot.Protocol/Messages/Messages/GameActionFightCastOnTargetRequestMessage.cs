using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightCastOnTargetRequestMessage : Message
	{

		// Properties
		public uint SpellId { get; set; }
		public int TargetId { get; set; }


		// Constructors
		public GameActionFightCastOnTargetRequestMessage() { }

		public GameActionFightCastOnTargetRequestMessage(uint spellId = 0, int targetId = 0)
		{
			SpellId = spellId;
			TargetId = targetId;
		}

	}
}
