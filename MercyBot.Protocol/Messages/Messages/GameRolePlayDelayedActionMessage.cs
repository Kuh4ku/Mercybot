using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayDelayedActionMessage : Message
	{

		// Properties
		public int DelayedCharacterId { get; set; }
		public uint DelayTypeId { get; set; }
		public double DelayEndTime { get; set; }


		// Constructors
		public GameRolePlayDelayedActionMessage() { }

		public GameRolePlayDelayedActionMessage(int delayedCharacterId = 0, uint delayTypeId = 0, double delayEndTime = 0)
		{
			DelayedCharacterId = delayedCharacterId;
			DelayTypeId = delayTypeId;
			DelayEndTime = delayEndTime;
		}

	}
}
