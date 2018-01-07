using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
	{

		// Properties
		public List<HumanOption> Options { get; set; }
		public uint SellType { get; set; }


		// Constructors
		public GameRolePlayMerchantInformations() { }

		public GameRolePlayMerchantInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "", uint sellType = 0, List<HumanOption> options = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
			SellType = sellType;
			Options = options;
		}

	}
}
