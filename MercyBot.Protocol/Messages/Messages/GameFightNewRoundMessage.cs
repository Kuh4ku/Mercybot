using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightNewRoundMessage : Message
	{

		// Properties
		public uint RoundNumber { get; set; }


		// Constructors
		public GameFightNewRoundMessage() { }

		public GameFightNewRoundMessage(uint roundNumber = 0)
		{
			RoundNumber = roundNumber;
		}

	}
}
