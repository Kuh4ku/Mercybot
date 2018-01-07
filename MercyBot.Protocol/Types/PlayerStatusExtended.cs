using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PlayerStatusExtended : PlayerStatus
	{

		// Properties
		public string Message { get; set; }


		// Constructors
		public PlayerStatusExtended() { }

		public PlayerStatusExtended(uint statusId = 1, string message = "")
		{
			StatusId = statusId;
			Message = message;
		}

	}
}
