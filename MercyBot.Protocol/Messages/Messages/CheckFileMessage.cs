using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CheckFileMessage : Message
	{

		// Properties
		public string FilenameHash { get; set; }
		public uint Type { get; set; }
		public string Value { get; set; }


		// Constructors
		public CheckFileMessage() { }

		public CheckFileMessage(string filenameHash = "", uint type = 0, string value = "")
		{
			FilenameHash = filenameHash;
			Type = type;
			Value = value;
		}

	}
}
