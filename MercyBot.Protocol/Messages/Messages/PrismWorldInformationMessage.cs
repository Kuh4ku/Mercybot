using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismWorldInformationMessage : Message
	{

		// Properties
		public List<PrismSubAreaInformation> SubAreasInformation { get; set; }
		public List<VillageConquestPrismInformation> ConquetesInformation { get; set; }
		public uint NbSubOwned { get; set; }
		public uint SubTotal { get; set; }
		public uint MaxSub { get; set; }
		public uint NbConqsOwned { get; set; }
		public uint ConqsTotal { get; set; }


		// Constructors
		public PrismWorldInformationMessage() { }

		public PrismWorldInformationMessage(uint nbSubOwned = 0, uint subTotal = 0, uint maxSub = 0, uint nbConqsOwned = 0, uint conqsTotal = 0, List<PrismSubAreaInformation> subAreasInformation = null, List<VillageConquestPrismInformation> conquetesInformation = null)
		{
			NbSubOwned = nbSubOwned;
			SubTotal = subTotal;
			MaxSub = maxSub;
			NbConqsOwned = nbConqsOwned;
			ConqsTotal = conqsTotal;
			SubAreasInformation = subAreasInformation;
			ConquetesInformation = conquetesInformation;
		}

	}
}
