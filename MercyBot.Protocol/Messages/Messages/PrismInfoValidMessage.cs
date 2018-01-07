using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismInfoValidMessage : Message
	{

		// Properties
		public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }


		// Constructors
		public PrismInfoValidMessage() { }

		public PrismInfoValidMessage(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo = null)
		{
			WaitingForHelpInfo = waitingForHelpInfo;
		}

	}
}
