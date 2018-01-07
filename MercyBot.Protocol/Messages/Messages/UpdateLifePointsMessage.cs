using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class UpdateLifePointsMessage : Message
	{

		// Properties
		public uint LifePoints { get; set; }
		public uint MaxLifePoints { get; set; }


		// Constructors
		public UpdateLifePointsMessage() { }

		public UpdateLifePointsMessage(uint lifePoints = 0, uint maxLifePoints = 0)
		{
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
		}

	}
}
