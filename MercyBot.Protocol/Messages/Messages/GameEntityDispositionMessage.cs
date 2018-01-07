using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameEntityDispositionMessage : Message
	{

		// Properties
		public IdentifiedEntityDispositionInformations Disposition { get; set; }


		// Constructors
		public GameEntityDispositionMessage() { }

		public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition = null)
		{
			Disposition = disposition;
		}

	}
}
