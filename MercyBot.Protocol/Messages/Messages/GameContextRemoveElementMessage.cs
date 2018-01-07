using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextRemoveElementMessage : Message
	{

		// Properties
		public int Id { get; set; }


		// Constructors
		public GameContextRemoveElementMessage() { }

		public GameContextRemoveElementMessage(int id = 0)
		{
			Id = id;
		}

	}
}
