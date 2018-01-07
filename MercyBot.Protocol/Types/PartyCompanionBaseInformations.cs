using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PartyCompanionBaseInformations
	{

		// Properties
		public uint IndexId { get; set; }
		public uint CompanionGenericId { get; set; }
		public EntityLook EntityLook { get; set; }


		// Constructors
		public PartyCompanionBaseInformations() { }

		public PartyCompanionBaseInformations(uint indexId = 0, uint companionGenericId = 0, EntityLook entityLook = null)
		{
			IndexId = indexId;
			CompanionGenericId = companionGenericId;
			EntityLook = entityLook;
		}

	}
}
