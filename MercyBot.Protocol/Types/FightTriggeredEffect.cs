using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTriggeredEffect : AbstractFightDispellableEffect
	{

		// Properties
		public int Param1 { get; set; }
		public int Param2 { get; set; }
		public int Param3 { get; set; }
		public int Delay { get; set; }


		// Constructors
		public FightTriggeredEffect() { }

		public FightTriggeredEffect(uint uid = 0, int targetId = 0, int turnDuration = 0, uint dispelable = 1, uint spellId = 0, uint parentBoostUid = 0, int param1 = 0, int param2 = 0, int param3 = 0, int delay = 0)
		{
			Uid = uid;
			TargetId = targetId;
			TurnDuration = turnDuration;
			Dispelable = dispelable;
			SpellId = spellId;
			ParentBoostUid = parentBoostUid;
			Param1 = param1;
			Param2 = param2;
			Param3 = param3;
			Delay = delay;
		}

	}
}
