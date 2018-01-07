using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementFinishedMessage : Message
	{

		// Properties
		public uint Id { get; set; }
		public uint Finishedlevel { get; set; }


		// Constructors
		public AchievementFinishedMessage() { }

		public AchievementFinishedMessage(uint id = 0, uint finishedlevel = 0)
		{
			Id = id;
			Finishedlevel = finishedlevel;
		}

	}
}
