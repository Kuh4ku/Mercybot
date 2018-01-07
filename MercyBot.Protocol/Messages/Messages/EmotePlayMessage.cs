using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EmotePlayMessage : EmotePlayAbstractMessage
	{

		// Properties
		public int ActorId { get; set; }
		public int AccountId { get; set; }


		// Constructors
		public EmotePlayMessage() { }

		public EmotePlayMessage(uint emoteId = 0, double emoteStartTime = 0, int actorId = 0, int accountId = 0)
		{
			EmoteId = emoteId;
			EmoteStartTime = emoteStartTime;
			ActorId = actorId;
			AccountId = accountId;
		}

	}
}
