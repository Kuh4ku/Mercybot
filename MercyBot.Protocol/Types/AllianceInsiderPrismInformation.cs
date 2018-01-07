using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AllianceInsiderPrismInformation : PrismInformation
	{

		// Properties
		public uint LastTimeSlotModificationDate { get; set; }
		public uint LastTimeSlotModificationAuthorGuildId { get; set; }
		public uint LastTimeSlotModificationAuthorId { get; set; }
		public string LastTimeSlotModificationAuthorName { get; set; }
		public bool HasTeleporterModule { get; set; }


		// Constructors
		public AllianceInsiderPrismInformation() { }

		public AllianceInsiderPrismInformation(uint typeId = 0, uint state = 1, uint nextVulnerabilityDate = 0, uint placementDate = 0, uint rewardTokenCount = 0, uint lastTimeSlotModificationDate = 0, uint lastTimeSlotModificationAuthorGuildId = 0, uint lastTimeSlotModificationAuthorId = 0, string lastTimeSlotModificationAuthorName = "", bool hasTeleporterModule = false)
		{
			TypeId = typeId;
			State = state;
			NextVulnerabilityDate = nextVulnerabilityDate;
			PlacementDate = placementDate;
			RewardTokenCount = rewardTokenCount;
			LastTimeSlotModificationDate = lastTimeSlotModificationDate;
			LastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
			LastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
			LastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
			HasTeleporterModule = hasTeleporterModule;
		}

	}
}
