using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
	{

		// Properties
		public uint Quantity { get; set; }


		// Constructors
		public ObjectItemInformationWithQuantity() { }

		public ObjectItemInformationWithQuantity(uint objectGID = 0, uint quantity = 0, List<ObjectEffect> effects = null)
		{
			ObjectGID = objectGID;
			Quantity = quantity;
			Effects = effects;
		}

	}
}
