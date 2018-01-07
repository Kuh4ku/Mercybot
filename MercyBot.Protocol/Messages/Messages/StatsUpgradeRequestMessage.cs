using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StatsUpgradeRequestMessage : Message
	{

		// Properties
		public uint StatId { get; set; }
		public uint BoostPoint { get; set; }


		// Constructors
		public StatsUpgradeRequestMessage() { }

		public StatsUpgradeRequestMessage(uint statId = 11, uint boostPoint = 0)
		{
			StatId = statId;
			BoostPoint = boostPoint;
		}

	}
}
