using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class IgnoredInformations : AbstractContactInformations
	{

		// Constructors
		public IgnoredInformations() { }

		public IgnoredInformations(uint accountId = 0, string accountName = "")
		{
			AccountId = accountId;
			AccountName = accountName;
		}

	}
}
