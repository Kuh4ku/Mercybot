using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
	{

		// Properties
		public int HouseId { get; set; }


		// Constructors
		public LockableStateUpdateHouseDoorMessage() { }

		public LockableStateUpdateHouseDoorMessage(bool locked = false, int houseId = 0)
		{
			Locked = locked;
			HouseId = houseId;
		}

	}
}
