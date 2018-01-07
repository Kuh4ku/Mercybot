using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorMovementMessage : Message
	{

		// Properties
		public bool HireOrFire { get; set; }
		public TaxCollectorBasicInformations BasicInfos { get; set; }
		public uint PlayerId { get; set; }
		public string PlayerName { get; set; }


		// Constructors
		public TaxCollectorMovementMessage() { }

		public TaxCollectorMovementMessage(bool hireOrFire = false, TaxCollectorBasicInformations basicInfos = null, uint playerId = 0, string playerName = "")
		{
			HireOrFire = hireOrFire;
			BasicInfos = basicInfos;
			PlayerId = playerId;
			PlayerName = playerName;
		}

	}
}
