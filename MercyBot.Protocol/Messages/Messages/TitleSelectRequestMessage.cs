using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TitleSelectRequestMessage : Message
	{

		// Properties
		public uint TitleId { get; set; }


		// Constructors
		public TitleSelectRequestMessage() { }

		public TitleSelectRequestMessage(uint titleId = 0)
		{
			TitleId = titleId;
		}

	}
}
