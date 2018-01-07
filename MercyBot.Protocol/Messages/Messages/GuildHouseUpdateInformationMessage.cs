using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildHouseUpdateInformationMessage : Message
	{

		// Properties
		public HouseInformationsForGuild HousesInformations { get; set; }


		// Constructors
		public GuildHouseUpdateInformationMessage() { }

		public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations = null)
		{
			HousesInformations = housesInformations;
		}

	}
}
