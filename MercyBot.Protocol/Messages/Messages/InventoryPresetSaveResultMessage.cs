using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetSaveResultMessage : Message
	{

		// Properties
		public uint PresetId { get; set; }
		public uint Code { get; set; }


		// Constructors
		public InventoryPresetSaveResultMessage() { }

		public InventoryPresetSaveResultMessage(uint presetId = 0, uint code = 2)
		{
			PresetId = presetId;
			Code = code;
		}

	}
}
