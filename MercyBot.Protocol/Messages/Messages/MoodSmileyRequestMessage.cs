using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MoodSmileyRequestMessage : Message
	{

		// Properties
		public int SmileyId { get; set; }


		// Constructors
		public MoodSmileyRequestMessage() { }

		public MoodSmileyRequestMessage(int smileyId = 0)
		{
			SmileyId = smileyId;
		}

	}
}
