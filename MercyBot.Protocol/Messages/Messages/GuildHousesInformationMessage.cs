using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildHousesInformationMessage : Message
	{

		// Properties
		public List<HouseInformationsForGuild> HousesInformations { get; set; }


		// Constructors
		public GuildHousesInformationMessage() { }

		public GuildHousesInformationMessage(List<HouseInformationsForGuild> housesInformations = null)
		{
			HousesInformations = housesInformations;
		}

	}
}
