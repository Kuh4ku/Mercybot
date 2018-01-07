using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class SellerBuyerDescriptor
	{

		// Properties
		public List<uint> Quantities { get; set; }
		public List<uint> Types { get; set; }
		public double TaxPercentage { get; set; }
		public double TaxModificationPercentage { get; set; }
		public uint MaxItemLevel { get; set; }
		public uint MaxItemPerAccount { get; set; }
		public int NpcContextualId { get; set; }
		public uint UnsoldDelay { get; set; }


		// Constructors
		public SellerBuyerDescriptor() { }

		public SellerBuyerDescriptor(double taxPercentage = 0, double taxModificationPercentage = 0, uint maxItemLevel = 0, uint maxItemPerAccount = 0, int npcContextualId = 0, uint unsoldDelay = 0, List<uint> quantities = null, List<uint> types = null)
		{
			TaxPercentage = taxPercentage;
			TaxModificationPercentage = taxModificationPercentage;
			MaxItemLevel = maxItemLevel;
			MaxItemPerAccount = maxItemPerAccount;
			NpcContextualId = npcContextualId;
			UnsoldDelay = unsoldDelay;
			Quantities = quantities;
			Types = types;
		}

	}
}
