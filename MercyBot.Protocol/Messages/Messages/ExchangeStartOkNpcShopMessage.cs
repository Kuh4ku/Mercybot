using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkNpcShopMessage : Message
	{

		// Properties
		public List<ObjectItemToSellInNpcShop> ObjectsInfos { get; set; }
		public int NpcSellerId { get; set; }
		public uint TokenId { get; set; }


		// Constructors
		public ExchangeStartOkNpcShopMessage() { }

		public ExchangeStartOkNpcShopMessage(int npcSellerId = 0, uint tokenId = 0, List<ObjectItemToSellInNpcShop> objectsInfos = null)
		{
			NpcSellerId = npcSellerId;
			TokenId = tokenId;
			ObjectsInfos = objectsInfos;
		}

	}
}
