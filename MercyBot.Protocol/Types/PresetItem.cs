using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PresetItem
	{

		// Properties
		public uint Position { get; set; }
		public uint ObjGid { get; set; }
		public uint ObjUid { get; set; }


		// Constructors
		public PresetItem() { }

		public PresetItem(uint position = 63, uint objGid = 0, uint objUid = 0)
		{
			Position = position;
			ObjGid = objGid;
			ObjUid = objUid;
		}

	}
}
