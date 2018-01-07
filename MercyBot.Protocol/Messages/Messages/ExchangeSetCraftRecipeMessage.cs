using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeSetCraftRecipeMessage : Message
	{

		// Properties
		public uint ObjectGID { get; set; }


		// Constructors
		public ExchangeSetCraftRecipeMessage() { }

		public ExchangeSetCraftRecipeMessage(uint objectGID = 0)
		{
			ObjectGID = objectGID;
		}

	}
}
