using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AbstractContactInformations
	{

		// Properties
		public uint AccountId { get; set; }
		public string AccountName { get; set; }


		// Constructors
		public AbstractContactInformations() { }

		public AbstractContactInformations(uint accountId = 0, string accountName = "")
		{
			AccountId = accountId;
			AccountName = accountName;
		}

	}
}
