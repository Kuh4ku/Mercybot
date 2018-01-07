using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryContentAndPresetMessage : InventoryContentMessage
	{

		// Properties
		public List<Preset> Presets { get; set; }


		// Constructors
		public InventoryContentAndPresetMessage() { }

		public InventoryContentAndPresetMessage(uint kamas = 0, List<ObjectItem> objects = null, List<Preset> presets = null)
		{
			Kamas = kamas;
			Objects = objects;
			Presets = presets;
		}

	}
}
