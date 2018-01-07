using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StatsUpgradeResultMessage : Message
	{

		// Properties
		public uint NbCharacBoost { get; set; }


		// Constructors
		public StatsUpgradeResultMessage() { }

		public StatsUpgradeResultMessage(uint nbCharacBoost = 0)
		{
			NbCharacBoost = nbCharacBoost;
		}

	}
}
