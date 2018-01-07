using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AdditionalTaxCollectorInformations
	{

		// Properties
		public string CollectorCallerName { get; set; }
		public uint Date { get; set; }


		// Constructors
		public AdditionalTaxCollectorInformations() { }

		public AdditionalTaxCollectorInformations(string collectorCallerName = "", uint date = 0)
		{
			CollectorCallerName = collectorCallerName;
			Date = date;
		}

	}
}
