using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DownloadPartMessage : Message
	{

		// Properties
		public string Id { get; set; }


		// Constructors
		public DownloadPartMessage() { }

		public DownloadPartMessage(string id = "")
		{
			Id = id;
		}

	}
}
