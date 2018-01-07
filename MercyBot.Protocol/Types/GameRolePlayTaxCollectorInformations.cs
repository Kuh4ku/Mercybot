using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
	{

		// Properties
		public TaxCollectorStaticInformations Identification { get; set; }
		public uint GuildLevel { get; set; }
		public int TaxCollectorAttack { get; set; }


		// Constructors
		public GameRolePlayTaxCollectorInformations() { }

		public GameRolePlayTaxCollectorInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, TaxCollectorStaticInformations identification = null, uint guildLevel = 0, int taxCollectorAttack = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Identification = identification;
			GuildLevel = guildLevel;
			TaxCollectorAttack = taxCollectorAttack;
		}

	}
}
