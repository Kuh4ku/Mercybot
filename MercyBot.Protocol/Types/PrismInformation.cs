using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PrismInformation
	{

		// Properties
		public uint TypeId { get; set; }
		public uint State { get; set; }
		public uint NextVulnerabilityDate { get; set; }
		public uint PlacementDate { get; set; }
		public uint RewardTokenCount { get; set; }


		// Constructors
		public PrismInformation() { }

		public PrismInformation(uint typeId = 0, uint state = 1, uint nextVulnerabilityDate = 0, uint placementDate = 0, uint rewardTokenCount = 0)
		{
			TypeId = typeId;
			State = state;
			NextVulnerabilityDate = nextVulnerabilityDate;
			PlacementDate = placementDate;
			RewardTokenCount = rewardTokenCount;
		}

	}
}
