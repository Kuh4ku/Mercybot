using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DownloadErrorMessage : Message
	{

		// Properties
		public uint ErrorId { get; set; }
		public string Message { get; set; }
		public string HelpUrl { get; set; }


		// Constructors
		public DownloadErrorMessage() { }

		public DownloadErrorMessage(uint errorId = 0, string message = "", string helpUrl = "")
		{
			ErrorId = errorId;
			Message = message;
			HelpUrl = helpUrl;
		}

	}
}
