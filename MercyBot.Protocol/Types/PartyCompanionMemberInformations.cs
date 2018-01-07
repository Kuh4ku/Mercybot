using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PartyCompanionMemberInformations : PartyCompanionBaseInformations
	{

		// Properties
		public uint Initiative { get; set; }
		public uint LifePoints { get; set; }
		public uint MaxLifePoints { get; set; }
		public uint Prospecting { get; set; }
		public uint RegenRate { get; set; }


		// Constructors
		public PartyCompanionMemberInformations() { }

		public PartyCompanionMemberInformations(uint indexId = 0, uint companionGenericId = 0, EntityLook entityLook = null, uint initiative = 0, uint lifePoints = 0, uint maxLifePoints = 0, uint prospecting = 0, uint regenRate = 0)
		{
			IndexId = indexId;
			CompanionGenericId = companionGenericId;
			EntityLook = entityLook;
			Initiative = initiative;
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
			Prospecting = prospecting;
			RegenRate = regenRate;
		}

	}
}
