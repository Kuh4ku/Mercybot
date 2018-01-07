using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectItemToSellInBid : ObjectItemToSell
	{

		// Properties
		public uint UnsoldDelay { get; set; }


		// Constructors
		public ObjectItemToSellInBid() { }

		public ObjectItemToSellInBid(uint objectGID = 0, uint objectUID = 0, uint quantity = 0, uint objectPrice = 0, uint unsoldDelay = 0, List<ObjectEffect> effects = null)
		{
			ObjectGID = objectGID;
			ObjectUID = objectUID;
			Quantity = quantity;
			ObjectPrice = objectPrice;
			UnsoldDelay = unsoldDelay;
			Effects = effects;
		}

	}
}
