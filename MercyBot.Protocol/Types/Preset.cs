using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class Preset
	{

		// Properties
		public List<PresetItem> Objects { get; set; }
		public uint PresetId { get; set; }
		public uint SymbolId { get; set; }
		public bool Mount { get; set; }


		// Constructors
		public Preset() { }

		public Preset(uint presetId = 0, uint symbolId = 0, bool mount = false, List<PresetItem> objects = null)
		{
			PresetId = presetId;
			SymbolId = symbolId;
			Mount = mount;
			Objects = objects;
		}

	}
}
