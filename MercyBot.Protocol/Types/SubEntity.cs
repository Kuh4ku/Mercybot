using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class SubEntity
	{

		// Properties
		public uint BindingPointCategory { get; set; }
		public uint BindingPointIndex { get; set; }
		public EntityLook SubEntityLook { get; set; }


		// Constructors
		public SubEntity() { }

		public SubEntity(uint bindingPointCategory = 0, uint bindingPointIndex = 0, EntityLook subEntityLook = null)
		{
			BindingPointCategory = bindingPointCategory;
			BindingPointIndex = bindingPointIndex;
			SubEntityLook = subEntityLook;
		}

	}
}
