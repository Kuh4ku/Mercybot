using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountSetXpRatioRequestMessage : Message
	{

		// Properties
		public uint XpRatio { get; set; }


		// Constructors
		public MountSetXpRatioRequestMessage() { }

		public MountSetXpRatioRequestMessage(uint xpRatio = 0)
		{
			XpRatio = xpRatio;
		}

	}
}
