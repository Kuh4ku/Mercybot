using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectItemToSell : Item
	{

		// Properties
		public List<ObjectEffect> Effects { get; set; }
		public uint ObjectGID { get; set; }
		public uint ObjectUID { get; set; }
		public uint Quantity { get; set; }
		public uint ObjectPrice { get; set; }


		// Constructors
		public ObjectItemToSell() { }

		public ObjectItemToSell(uint objectGID = 0, uint objectUID = 0, uint quantity = 0, uint objectPrice = 0, List<ObjectEffect> effects = null)
		{
			ObjectGID = objectGID;
			ObjectUID = objectUID;
			Quantity = quantity;
			ObjectPrice = objectPrice;
			Effects = effects;
		}

	}
}
