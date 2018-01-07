using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MoodSmileyResultMessage : Message
	{

		// Properties
		public uint ResultCode { get; set; }
		public int SmileyId { get; set; }


		// Constructors
		public MoodSmileyResultMessage() { }

		public MoodSmileyResultMessage(uint resultCode = 1, int smileyId = 0)
		{
			ResultCode = resultCode;
			SmileyId = smileyId;
		}

	}
}
