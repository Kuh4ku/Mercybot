using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightAttackerAddMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public double FightId { get; set; }
		public CharacterMinimalPlusLookInformations Attacker { get; set; }


		// Constructors
		public PrismFightAttackerAddMessage() { }

		public PrismFightAttackerAddMessage(uint subAreaId = 0, double fightId = 0, CharacterMinimalPlusLookInformations attacker = null)
		{
			SubAreaId = subAreaId;
			FightId = fightId;
			Attacker = attacker;
		}

	}
}
