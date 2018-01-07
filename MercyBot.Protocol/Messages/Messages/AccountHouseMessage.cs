using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AccountHouseMessage : Message
	{

		// Properties
		public List<AccountHouseInformations> Houses { get; set; }


		// Constructors
		public AccountHouseMessage() { }

		public AccountHouseMessage(List<AccountHouseInformations> houses = null)
		{
			Houses = houses;
		}

	}
}
