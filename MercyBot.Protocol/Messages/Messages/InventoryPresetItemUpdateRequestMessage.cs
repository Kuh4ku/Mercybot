using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetItemUpdateRequestMessage : Message
	{

		// Properties
		public uint PresetId { get; set; }
		public uint Position { get; set; }
		public uint ObjUid { get; set; }


		// Constructors
		public InventoryPresetItemUpdateRequestMessage() { }

		public InventoryPresetItemUpdateRequestMessage(uint presetId = 0, uint position = 63, uint objUid = 0)
		{
			PresetId = presetId;
			Position = position;
			ObjUid = objUid;
		}

	}
}
