using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightDispellableEffectExtendedInformations
	{

		// Properties
		public uint ActionId { get; set; }
		public int SourceId { get; set; }
		public AbstractFightDispellableEffect Effect { get; set; }


		// Constructors
		public FightDispellableEffectExtendedInformations() { }

		public FightDispellableEffectExtendedInformations(uint actionId = 0, int sourceId = 0, AbstractFightDispellableEffect effect = null)
		{
			ActionId = actionId;
			SourceId = sourceId;
			Effect = effect;
		}

	}
}
