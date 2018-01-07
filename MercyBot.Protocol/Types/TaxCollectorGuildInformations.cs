using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
	{

		// Properties
		public BasicGuildInformations Guild { get; set; }


		// Constructors
		public TaxCollectorGuildInformations() { }

		public TaxCollectorGuildInformations(BasicGuildInformations guild = null)
		{
			Guild = guild;
		}

	}
}
