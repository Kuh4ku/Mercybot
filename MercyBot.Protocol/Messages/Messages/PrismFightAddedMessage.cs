using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightAddedMessage : Message
	{

		// Properties
		public PrismFightersInformation Fight { get; set; }


		// Constructors
		public PrismFightAddedMessage() { }

		public PrismFightAddedMessage(PrismFightersInformation fight = null)
		{
			Fight = fight;
		}

	}
}
