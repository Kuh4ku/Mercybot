using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ShortcutObjectItem : ShortcutObject
	{

		// Properties
		public int ItemUID { get; set; }
		public int ItemGID { get; set; }


		// Constructors
		public ShortcutObjectItem() { }

		public ShortcutObjectItem(uint slot = 0, int itemUID = 0, int itemGID = 0)
		{
			Slot = slot;
			ItemUID = itemUID;
			ItemGID = itemGID;
		}

	}
}
