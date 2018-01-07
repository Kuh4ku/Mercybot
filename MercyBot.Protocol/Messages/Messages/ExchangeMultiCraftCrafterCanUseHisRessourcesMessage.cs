using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : Message
	{

		// Properties
		public bool Allowed { get; set; }


		// Constructors
		public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage() { }

		public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed = false)
		{
			Allowed = allowed;
		}

	}
}
