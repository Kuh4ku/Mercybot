using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetUseMessage : Message
	{

		// Properties
		public uint PresetId { get; set; }


		// Constructors
		public InventoryPresetUseMessage() { }

		public InventoryPresetUseMessage(uint presetId = 0)
		{
			PresetId = presetId;
		}

	}
}
