using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AlliancePrismInformation : PrismInformation
	{

		// Properties
		public AllianceInformations Alliance { get; set; }


		// Constructors
		public AlliancePrismInformation() { }

		public AlliancePrismInformation(uint typeId = 0, uint state = 1, uint nextVulnerabilityDate = 0, uint placementDate = 0, uint rewardTokenCount = 0, AllianceInformations alliance = null)
		{
			TypeId = typeId;
			State = state;
			NextVulnerabilityDate = nextVulnerabilityDate;
			PlacementDate = placementDate;
			RewardTokenCount = rewardTokenCount;
			Alliance = alliance;
		}

	}
}
