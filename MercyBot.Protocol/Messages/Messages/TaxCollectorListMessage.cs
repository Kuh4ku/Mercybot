using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorListMessage : Message
	{

		// Properties
		public List<TaxCollectorInformations> Informations { get; set; }
		public List<TaxCollectorFightersInformation> FightersInformations { get; set; }
		public uint NbcollectorMax { get; set; }


		// Constructors
		public TaxCollectorListMessage() { }

		public TaxCollectorListMessage(uint nbcollectorMax = 0, List<TaxCollectorInformations> informations = null, List<TaxCollectorFightersInformation> fightersInformations = null)
		{
			NbcollectorMax = nbcollectorMax;
			Informations = informations;
			FightersInformations = fightersInformations;
		}

	}
}
