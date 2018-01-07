using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightDefendersSwapMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public double FightId { get; set; }
		public uint FighterId1 { get; set; }
		public uint FighterId2 { get; set; }


		// Constructors
		public PrismFightDefendersSwapMessage() { }

		public PrismFightDefendersSwapMessage(uint subAreaId = 0, double fightId = 0, uint fighterId1 = 0, uint fighterId2 = 0)
		{
			SubAreaId = subAreaId;
			FightId = fightId;
			FighterId1 = fighterId1;
			FighterId2 = fighterId2;
		}

	}
}
