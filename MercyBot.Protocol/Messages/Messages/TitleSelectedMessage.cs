using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TitleSelectedMessage : Message
	{

		// Properties
		public uint TitleId { get; set; }


		// Constructors
		public TitleSelectedMessage() { }

		public TitleSelectedMessage(uint titleId = 0)
		{
			TitleId = titleId;
		}

	}
}
