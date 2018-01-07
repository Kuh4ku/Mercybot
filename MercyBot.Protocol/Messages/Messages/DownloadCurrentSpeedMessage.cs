using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DownloadCurrentSpeedMessage : Message
	{

		// Properties
		public uint DownloadSpeed { get; set; }


		// Constructors
		public DownloadCurrentSpeedMessage() { }

		public DownloadCurrentSpeedMessage(uint downloadSpeed = 0)
		{
			DownloadSpeed = downloadSpeed;
		}

	}
}
