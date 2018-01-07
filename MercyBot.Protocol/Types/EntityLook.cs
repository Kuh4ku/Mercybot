using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class EntityLook
	{

		// Properties
		public List<uint> Skins { get; set; }
		public List<int> IndexedColors { get; set; }
		public List<int> Scales { get; set; }
		public List<SubEntity> Subentities { get; set; }
		public uint BonesId { get; set; }


		// Constructors
		public EntityLook() { }

		public EntityLook(uint bonesId = 0, List<uint> skins = null, List<int> indexedColors = null, List<int> scales = null, List<SubEntity> subentities = null)
		{
			BonesId = bonesId;
			Skins = skins;
			IndexedColors = indexedColors;
			Scales = scales;
			Subentities = subentities;
		}

	}
}
