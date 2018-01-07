using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class BidExchangerObjectInfo
	{

		// Properties
		public List<ObjectEffect> Effects { get; set; }
		public List<uint> Prices { get; set; }
		public uint ObjectUID { get; set; }


		// Constructors
		public BidExchangerObjectInfo() { }

		public BidExchangerObjectInfo(uint objectUID = 0, List<ObjectEffect> effects = null, List<uint> prices = null)
		{
			ObjectUID = objectUID;
			Effects = effects;
			Prices = prices;
		}

	}
}
