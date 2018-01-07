using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameMapMovementCancelMessage : Message
	{

		// Properties
		public uint CellId { get; set; }


		// Constructors
		public GameMapMovementCancelMessage() { }

		public GameMapMovementCancelMessage(uint cellId = 0)
		{
			CellId = cellId;
		}

	}
}
