using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LifePointsRegenBeginMessage : Message
	{

		// Properties
		public uint RegenRate { get; set; }


		// Constructors
		public LifePointsRegenBeginMessage() { }

		public LifePointsRegenBeginMessage(uint regenRate = 0)
		{
			RegenRate = regenRate;
		}

	}
}
