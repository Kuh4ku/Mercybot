using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : Message
	{

		// Properties
		public bool Allow { get; set; }


		// Constructors
		public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage() { }

		public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow = false)
		{
			Allow = allow;
		}

	}
}
