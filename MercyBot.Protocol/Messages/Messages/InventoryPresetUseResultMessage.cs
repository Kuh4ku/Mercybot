using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetUseResultMessage : Message
	{

		// Properties
		public List<uint> UnlinkedPosition { get; set; }
		public uint PresetId { get; set; }
		public uint Code { get; set; }


		// Constructors
		public InventoryPresetUseResultMessage() { }

		public InventoryPresetUseResultMessage(uint presetId = 0, uint code = 3, List<uint> unlinkedPosition = null)
		{
			PresetId = presetId;
			Code = code;
			UnlinkedPosition = unlinkedPosition;
		}

	}
}
