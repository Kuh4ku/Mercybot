using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
	{

		// Properties
		public int MapId { get; set; }
		public uint ElementId { get; set; }


		// Constructors
		public LockableStateUpdateStorageMessage() { }

		public LockableStateUpdateStorageMessage(bool locked = false, int mapId = 0, uint elementId = 0)
		{
			Locked = locked;
			MapId = mapId;
			ElementId = elementId;
		}

	}
}
