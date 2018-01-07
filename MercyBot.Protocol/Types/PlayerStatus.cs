using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PlayerStatus
	{

		// Properties
		public uint StatusId { get; set; }


		// Constructors
		public PlayerStatus() { }

		public PlayerStatus(uint statusId = 1)
		{
			StatusId = statusId;
		}

	}
}
