using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorMovementAddMessage : Message
	{

		// Properties
		public TaxCollectorInformations Informations { get; set; }


		// Constructors
		public TaxCollectorMovementAddMessage() { }

		public TaxCollectorMovementAddMessage(TaxCollectorInformations informations = null)
		{
			Informations = informations;
		}

	}
}
