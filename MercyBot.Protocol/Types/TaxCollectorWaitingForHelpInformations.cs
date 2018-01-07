using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
	{

		// Properties
		public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }


		// Constructors
		public TaxCollectorWaitingForHelpInformations() { }

		public TaxCollectorWaitingForHelpInformations(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo = null)
		{
			WaitingForHelpInfo = waitingForHelpInfo;
		}

	}
}
