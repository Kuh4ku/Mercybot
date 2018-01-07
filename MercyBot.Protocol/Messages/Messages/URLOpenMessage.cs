using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class URLOpenMessage : Message
	{

		// Properties
		public uint UrlId { get; set; }


		// Constructors
		public URLOpenMessage() { }

		public URLOpenMessage(uint urlId = 0)
		{
			UrlId = urlId;
		}

	}
}
