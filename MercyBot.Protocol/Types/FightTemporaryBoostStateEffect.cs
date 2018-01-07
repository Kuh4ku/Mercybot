using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
	{

		// Properties
		public int StateId { get; set; }


		// Constructors
		public FightTemporaryBoostStateEffect() { }

		public FightTemporaryBoostStateEffect(uint uid = 0, int targetId = 0, int turnDuration = 0, uint dispelable = 1, uint spellId = 0, uint parentBoostUid = 0, int delta = 0, int stateId = 0)
		{
			Uid = uid;
			TargetId = targetId;
			TurnDuration = turnDuration;
			Dispelable = dispelable;
			SpellId = spellId;
			ParentBoostUid = parentBoostUid;
			Delta = delta;
			StateId = stateId;
		}

	}
}
