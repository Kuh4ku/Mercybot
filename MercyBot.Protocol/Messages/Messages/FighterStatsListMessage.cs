using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FighterStatsListMessage : Message
	{

		// Properties
		public CharacterCharacteristicsInformations Stats { get; set; }


		// Constructors
		public FighterStatsListMessage() { }

		public FighterStatsListMessage(CharacterCharacteristicsInformations stats = null)
		{
			Stats = stats;
		}

	}
}
