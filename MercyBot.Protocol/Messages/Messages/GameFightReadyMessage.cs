using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightReadyMessage : Message
	{

		// Properties
		public bool IsReady { get; set; }


		// Constructors
		public GameFightReadyMessage() { }

		public GameFightReadyMessage(bool isReady = false)
		{
			IsReady = isReady;
		}

	}
}
