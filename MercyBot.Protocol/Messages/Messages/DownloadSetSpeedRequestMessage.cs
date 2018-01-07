using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DownloadSetSpeedRequestMessage : Message
	{

		// Properties
		public uint DownloadSpeed { get; set; }


		// Constructors
		public DownloadSetSpeedRequestMessage() { }

		public DownloadSetSpeedRequestMessage(uint downloadSpeed = 0)
		{
			DownloadSpeed = downloadSpeed;
		}

	}
}
