using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AbstractFightDispellableEffect
	{

		// Properties
		public uint Uid { get; set; }
		public int TargetId { get; set; }
		public int TurnDuration { get; set; }
		public uint Dispelable { get; set; }
		public uint SpellId { get; set; }
		public uint ParentBoostUid { get; set; }


		// Constructors
		public AbstractFightDispellableEffect() { }

		public AbstractFightDispellableEffect(uint uid = 0, int targetId = 0, int turnDuration = 0, uint dispelable = 1, uint spellId = 0, uint parentBoostUid = 0)
		{
			Uid = uid;
			TargetId = targetId;
			TurnDuration = turnDuration;
			Dispelable = dispelable;
			SpellId = spellId;
			ParentBoostUid = parentBoostUid;
		}

	}
}
