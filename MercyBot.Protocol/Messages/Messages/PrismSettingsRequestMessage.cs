using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismSettingsRequestMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public uint StartDefenseTime { get; set; }


		// Constructors
		public PrismSettingsRequestMessage() { }

		public PrismSettingsRequestMessage(uint subAreaId = 0, uint startDefenseTime = 0)
		{
			SubAreaId = subAreaId;
			StartDefenseTime = startDefenseTime;
		}

	}
}
