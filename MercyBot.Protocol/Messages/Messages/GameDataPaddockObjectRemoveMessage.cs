using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameDataPaddockObjectRemoveMessage : Message
	{

		// Properties
		public uint CellId { get; set; }


		// Constructors
		public GameDataPaddockObjectRemoveMessage() { }

		public GameDataPaddockObjectRemoveMessage(uint cellId = 0)
		{
			CellId = cellId;
		}

	}
}
