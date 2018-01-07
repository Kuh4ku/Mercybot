using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyUpdateLightMessage : AbstractPartyEventMessage
	{

		// Properties
		public uint Id { get; set; }
		public uint LifePoints { get; set; }
		public uint MaxLifePoints { get; set; }
		public uint Prospecting { get; set; }
		public uint RegenRate { get; set; }


		// Constructors
		public PartyUpdateLightMessage() { }

		public PartyUpdateLightMessage(uint partyId = 0, uint id = 0, uint lifePoints = 0, uint maxLifePoints = 0, uint prospecting = 0, uint regenRate = 0)
		{
			PartyId = partyId;
			Id = id;
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
			Prospecting = prospecting;
			RegenRate = regenRate;
		}

	}
}
