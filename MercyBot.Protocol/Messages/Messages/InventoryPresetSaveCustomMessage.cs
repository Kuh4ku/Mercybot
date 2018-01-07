using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetSaveCustomMessage : Message
	{

		// Properties
		public List<uint> ItemsPositions { get; set; }
		public List<uint> ItemsUids { get; set; }
		public uint PresetId { get; set; }
		public uint SymbolId { get; set; }


		// Constructors
		public InventoryPresetSaveCustomMessage() { }

		public InventoryPresetSaveCustomMessage(uint presetId = 0, uint symbolId = 0, List<uint> itemsPositions = null, List<uint> itemsUids = null)
		{
			PresetId = presetId;
			SymbolId = symbolId;
			ItemsPositions = itemsPositions;
			ItemsUids = itemsUids;
		}

	}
}
