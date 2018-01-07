using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TitleGainedMessage : Message
	{

		// Properties
		public uint TitleId { get; set; }


		// Constructors
		public TitleGainedMessage() { }

		public TitleGainedMessage(uint titleId = 0)
		{
			TitleId = titleId;
		}

	}
}
