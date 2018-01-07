using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartInfoMessage : Message
	{

		// Properties
		public ContentPart Part { get; set; }
		public double InstallationPercent { get; set; }


		// Constructors
		public PartInfoMessage() { }

		public PartInfoMessage(ContentPart part = null, double installationPercent = 0)
		{
			Part = part;
			InstallationPercent = installationPercent;
		}

	}
}
