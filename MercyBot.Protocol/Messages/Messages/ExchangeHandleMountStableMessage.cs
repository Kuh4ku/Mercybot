using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeHandleMountStableMessage : Message
	{

		// Properties
		public int ActionType { get; set; }
		public uint RideId { get; set; }


		// Constructors
		public ExchangeHandleMountStableMessage() { }

		public ExchangeHandleMountStableMessage(int actionType = 0, uint rideId = 0)
		{
			ActionType = actionType;
			RideId = rideId;
		}

	}
}
