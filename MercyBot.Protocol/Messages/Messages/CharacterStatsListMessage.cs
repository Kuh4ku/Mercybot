using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterStatsListMessage : Message
	{

		// Properties
		public CharacterCharacteristicsInformations Stats { get; set; }


		// Constructors
		public CharacterStatsListMessage() { }

		public CharacterStatsListMessage(CharacterCharacteristicsInformations stats = null)
		{
			Stats = stats;
		}

	}
}
