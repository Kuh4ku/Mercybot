using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ShortcutObjectPreset : ShortcutObject
	{

		// Properties
		public uint PresetId { get; set; }


		// Constructors
		public ShortcutObjectPreset() { }

		public ShortcutObjectPreset(uint slot = 0, uint presetId = 0)
		{
			Slot = slot;
			PresetId = presetId;
		}

	}
}
