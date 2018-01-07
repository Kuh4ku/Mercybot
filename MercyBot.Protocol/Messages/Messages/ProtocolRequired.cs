using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ProtocolRequired : Message
	{

		// Properties
		public uint RequiredVersion { get; set; }
		public uint CurrentVersion { get; set; }


		// Constructors
		public ProtocolRequired() { }

		public ProtocolRequired(uint requiredVersion = 0, uint currentVersion = 0)
		{
			RequiredVersion = requiredVersion;
			CurrentVersion = currentVersion;
		}

	}
}
