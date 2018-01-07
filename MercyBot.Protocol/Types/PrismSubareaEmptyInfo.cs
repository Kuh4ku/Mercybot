using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PrismSubareaEmptyInfo
	{

		// Properties
		public uint SubAreaId { get; set; }
		public uint AllianceId { get; set; }


		// Constructors
		public PrismSubareaEmptyInfo() { }

		public PrismSubareaEmptyInfo(uint subAreaId = 0, uint allianceId = 0)
		{
			SubAreaId = subAreaId;
			AllianceId = allianceId;
		}

	}
}
