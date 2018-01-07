using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountXpRatioMessage : Message
	{

		// Properties
		public uint Ratio { get; set; }


		// Constructors
		public MountXpRatioMessage() { }

		public MountXpRatioMessage(uint ratio = 0)
		{
			Ratio = ratio;
		}

	}
}
