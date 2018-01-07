using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightJoinLeaveRequestMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public bool Join { get; set; }


		// Constructors
		public PrismFightJoinLeaveRequestMessage() { }

		public PrismFightJoinLeaveRequestMessage(uint subAreaId = 0, bool join = false)
		{
			SubAreaId = subAreaId;
			Join = join;
		}

	}
}
