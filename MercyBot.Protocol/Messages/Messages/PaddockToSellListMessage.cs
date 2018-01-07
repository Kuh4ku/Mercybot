using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockToSellListMessage : Message
	{

		// Properties
		public List<PaddockInformationsForSell> PaddockList { get; set; }
		public uint PageIndex { get; set; }
		public uint TotalPage { get; set; }


		// Constructors
		public PaddockToSellListMessage() { }

		public PaddockToSellListMessage(uint pageIndex = 0, uint totalPage = 0, List<PaddockInformationsForSell> paddockList = null)
		{
			PageIndex = pageIndex;
			TotalPage = totalPage;
			PaddockList = paddockList;
		}

	}
}
