using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightLeaveRequestMessage : Message
	{

		// Properties
		public int TaxCollectorId { get; set; }
		public uint CharacterId { get; set; }


		// Constructors
		public GuildFightLeaveRequestMessage() { }

		public GuildFightLeaveRequestMessage(int taxCollectorId = 0, uint characterId = 0)
		{
			TaxCollectorId = taxCollectorId;
			CharacterId = characterId;
		}

	}
}
