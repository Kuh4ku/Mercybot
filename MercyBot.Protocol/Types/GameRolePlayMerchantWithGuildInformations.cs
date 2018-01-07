using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayMerchantWithGuildInformations : GameRolePlayMerchantInformations
	{

		// Properties
		public GuildInformations GuildInformations { get; set; }


		// Constructors
		public GameRolePlayMerchantWithGuildInformations() { }

		public GameRolePlayMerchantWithGuildInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "", uint sellType = 0, GuildInformations guildInformations = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
			SellType = sellType;
			GuildInformations = guildInformations;
		}

	}
}
