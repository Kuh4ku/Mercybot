using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightJoinRequestMessage : Message
	{

		// Properties
		public int TaxCollectorId { get; set; }


		// Constructors
		public GuildFightJoinRequestMessage() { }

		public GuildFightJoinRequestMessage(int taxCollectorId = 0)
		{
			TaxCollectorId = taxCollectorId;
		}

	}
}
