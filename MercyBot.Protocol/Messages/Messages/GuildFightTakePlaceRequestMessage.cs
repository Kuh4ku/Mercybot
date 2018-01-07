using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
	{

		// Properties
		public int ReplacedCharacterId { get; set; }


		// Constructors
		public GuildFightTakePlaceRequestMessage() { }

		public GuildFightTakePlaceRequestMessage(int taxCollectorId = 0, int replacedCharacterId = 0)
		{
			TaxCollectorId = taxCollectorId;
			ReplacedCharacterId = replacedCharacterId;
		}

	}
}
