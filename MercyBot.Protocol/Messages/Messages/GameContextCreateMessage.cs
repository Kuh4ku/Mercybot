using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextCreateMessage : Message
	{

		// Properties
		public uint Context { get; set; }


		// Constructors
		public GameContextCreateMessage() { }

		public GameContextCreateMessage(uint context = 1)
		{
			Context = context;
		}

	}
}
