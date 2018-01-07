using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementFinishedInformationMessage : AchievementFinishedMessage
	{

		// Properties
		public string Name { get; set; }
		public uint PlayerId { get; set; }


		// Constructors
		public AchievementFinishedInformationMessage() { }

		public AchievementFinishedInformationMessage(uint id = 0, uint finishedlevel = 0, string name = "", uint playerId = 0)
		{
			Id = id;
			Finishedlevel = finishedlevel;
			Name = name;
			PlayerId = playerId;
		}

	}
}
