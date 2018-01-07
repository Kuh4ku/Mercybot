using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetSaveMessage : Message
	{

		// Properties
		public uint PresetId { get; set; }
		public uint SymbolId { get; set; }
		public bool SaveEquipment { get; set; }


		// Constructors
		public InventoryPresetSaveMessage() { }

		public InventoryPresetSaveMessage(uint presetId = 0, uint symbolId = 0, bool saveEquipment = false)
		{
			PresetId = presetId;
			SymbolId = symbolId;
			SaveEquipment = saveEquipment;
		}

	}
}
