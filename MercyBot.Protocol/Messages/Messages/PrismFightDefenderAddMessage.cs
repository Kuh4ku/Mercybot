using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightDefenderAddMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public double FightId { get; set; }
		public CharacterMinimalPlusLookInformations Defender { get; set; }


		// Constructors
		public PrismFightDefenderAddMessage() { }

		public PrismFightDefenderAddMessage(uint subAreaId = 0, double fightId = 0, CharacterMinimalPlusLookInformations defender = null)
		{
			SubAreaId = subAreaId;
			FightId = fightId;
			Defender = defender;
		}

	}
}
