using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CheckFileRequestMessage : Message
	{

		// Properties
		public string Filename { get; set; }
		public uint Type { get; set; }


		// Constructors
		public CheckFileRequestMessage() { }

		public CheckFileRequestMessage(string filename = "", uint type = 0)
		{
			Filename = filename;
			Type = type;
		}

	}
}
