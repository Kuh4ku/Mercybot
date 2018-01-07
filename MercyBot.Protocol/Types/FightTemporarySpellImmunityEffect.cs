using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
	{

		// Properties
		public int ImmuneSpellId { get; set; }


		// Constructors
		public FightTemporarySpellImmunityEffect() { }

		public FightTemporarySpellImmunityEffect(uint uid = 0, int targetId = 0, int turnDuration = 0, uint dispelable = 1, uint spellId = 0, uint parentBoostUid = 0, int immuneSpellId = 0)
		{
			Uid = uid;
			TargetId = targetId;
			TurnDuration = turnDuration;
			Dispelable = dispelable;
			SpellId = spellId;
			ParentBoostUid = parentBoostUid;
			ImmuneSpellId = immuneSpellId;
		}

	}
}
