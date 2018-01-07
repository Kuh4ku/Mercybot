using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HumanOptionObjectUse : HumanOption
	{

		// Properties
		public uint DelayTypeId { get; set; }
		public double DelayEndTime { get; set; }
		public uint ObjectGID { get; set; }


		// Constructors
		public HumanOptionObjectUse() { }

		public HumanOptionObjectUse(uint delayTypeId = 0, double delayEndTime = 0, uint objectGID = 0)
		{
			DelayTypeId = delayTypeId;
			DelayEndTime = delayEndTime;
			ObjectGID = objectGID;
		}

	}
}
