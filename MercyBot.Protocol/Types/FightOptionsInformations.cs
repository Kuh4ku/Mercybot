using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightOptionsInformations
	{

		// Properties
		public bool IsSecret { get; set; }
		public bool IsRestrictedToPartyOnly { get; set; }
		public bool IsClosed { get; set; }
		public bool IsAskingForHelp { get; set; }


		// Constructors
		public FightOptionsInformations() { }

		public FightOptionsInformations(bool isSecret = false, bool isRestrictedToPartyOnly = false, bool isClosed = false, bool isAskingForHelp = false)
		{
			IsSecret = isSecret;
			IsRestrictedToPartyOnly = isRestrictedToPartyOnly;
			IsClosed = isClosed;
			IsAskingForHelp = isAskingForHelp;
		}

	}
}
