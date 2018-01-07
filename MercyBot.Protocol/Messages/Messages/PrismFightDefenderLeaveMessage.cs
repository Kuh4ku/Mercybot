using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightDefenderLeaveMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public double FightId { get; set; }
		public uint FighterToRemoveId { get; set; }


		// Constructors
		public PrismFightDefenderLeaveMessage() { }

		public PrismFightDefenderLeaveMessage(uint subAreaId = 0, double fightId = 0, uint fighterToRemoveId = 0)
		{
			SubAreaId = subAreaId;
			FightId = fightId;
			FighterToRemoveId = fighterToRemoveId;
		}

	}
}
