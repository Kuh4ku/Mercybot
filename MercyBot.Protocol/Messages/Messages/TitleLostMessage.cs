using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TitleLostMessage : Message
	{

		// Properties
		public uint TitleId { get; set; }


		// Constructors
		public TitleLostMessage() { }

		public TitleLostMessage(uint titleId = 0)
		{
			TitleId = titleId;
		}

	}
}
