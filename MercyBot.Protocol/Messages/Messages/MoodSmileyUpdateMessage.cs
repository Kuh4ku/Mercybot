using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MoodSmileyUpdateMessage : Message
	{

		// Properties
		public uint AccountId { get; set; }
		public uint PlayerId { get; set; }
		public int SmileyId { get; set; }


		// Constructors
		public MoodSmileyUpdateMessage() { }

		public MoodSmileyUpdateMessage(uint accountId = 0, uint playerId = 0, int smileyId = 0)
		{
			AccountId = accountId;
			PlayerId = playerId;
			SmileyId = smileyId;
		}

	}
}
