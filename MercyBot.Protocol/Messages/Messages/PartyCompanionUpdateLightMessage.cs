using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyCompanionUpdateLightMessage : PartyUpdateLightMessage
	{

		// Properties
		public uint IndexId { get; set; }


		// Constructors
		public PartyCompanionUpdateLightMessage() { }

		public PartyCompanionUpdateLightMessage(uint partyId = 0, uint id = 0, uint lifePoints = 0, uint maxLifePoints = 0, uint prospecting = 0, uint regenRate = 0, uint indexId = 0)
		{
			PartyId = partyId;
			Id = id;
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
			Prospecting = prospecting;
			RegenRate = regenRate;
			IndexId = indexId;
		}

	}
}
