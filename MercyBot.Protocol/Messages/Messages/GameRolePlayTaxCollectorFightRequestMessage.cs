using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayTaxCollectorFightRequestMessage : Message
	{

		// Properties
		public int TaxCollectorId { get; set; }


		// Constructors
		public GameRolePlayTaxCollectorFightRequestMessage() { }

		public GameRolePlayTaxCollectorFightRequestMessage(int taxCollectorId = 0)
		{
			TaxCollectorId = taxCollectorId;
		}

	}
}
