using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MimicryObjectFeedAndAssociateRequestMessage : Message
	{

		// Properties
		public uint MimicryUID { get; set; }
		public uint MimicryPos { get; set; }
		public uint FoodUID { get; set; }
		public uint FoodPos { get; set; }
		public uint HostUID { get; set; }
		public uint HostPos { get; set; }
		public bool Preview { get; set; }


		// Constructors
		public MimicryObjectFeedAndAssociateRequestMessage() { }

		public MimicryObjectFeedAndAssociateRequestMessage(uint mimicryUID = 0, uint mimicryPos = 0, uint foodUID = 0, uint foodPos = 0, uint hostUID = 0, uint hostPos = 0, bool preview = false)
		{
			MimicryUID = mimicryUID;
			MimicryPos = mimicryPos;
			FoodUID = foodUID;
			FoodPos = foodPos;
			HostUID = hostUID;
			HostPos = hostPos;
			Preview = preview;
		}

	}
}
