using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
	{

		// Properties
		public uint BoostedSpellId { get; set; }


		// Constructors
		public FightTemporarySpellBoostEffect() { }

		public FightTemporarySpellBoostEffect(uint uid = 0, int targetId = 0, int turnDuration = 0, uint dispelable = 1, uint spellId = 0, uint parentBoostUid = 0, int delta = 0, uint boostedSpellId = 0)
		{
			Uid = uid;
			TargetId = targetId;
			TurnDuration = turnDuration;
			Dispelable = dispelable;
			SpellId = spellId;
			ParentBoostUid = parentBoostUid;
			Delta = delta;
			BoostedSpellId = boostedSpellId;
		}

	}
}
