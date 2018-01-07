using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseInListAddedMessage : Message
	{

		// Properties
		public List<ObjectEffect> Effects { get; set; }
		public List<uint> Prices { get; set; }
		public int ItemUID { get; set; }
		public int ObjGenericId { get; set; }


		// Constructors
		public ExchangeBidHouseInListAddedMessage() { }

		public ExchangeBidHouseInListAddedMessage(int itemUID = 0, int objGenericId = 0, List<ObjectEffect> effects = null, List<uint> prices = null)
		{
			ItemUID = itemUID;
			ObjGenericId = objGenericId;
			Effects = effects;
			Prices = prices;
		}

	}
}
