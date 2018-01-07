using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlaySpellAnimMessage : Message
	{

		// Properties
		public int CasterId { get; set; }
		public uint TargetCellId { get; set; }
		public uint SpellId { get; set; }
		public uint SpellLevel { get; set; }


		// Constructors
		public GameRolePlaySpellAnimMessage() { }

		public GameRolePlaySpellAnimMessage(int casterId = 0, uint targetCellId = 0, uint spellId = 0, uint spellLevel = 0)
		{
			CasterId = casterId;
			TargetCellId = targetCellId;
			SpellId = spellId;
			SpellLevel = spellLevel;
		}

	}
}
