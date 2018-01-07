using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountTakenFromPaddockMessage : Message
	{

		// Properties
		public string Name { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public string Ownername { get; set; }


		// Constructors
		public ExchangeMountTakenFromPaddockMessage() { }

		public ExchangeMountTakenFromPaddockMessage(string name = "", int worldX = 0, int worldY = 0, string ownername = "")
		{
			Name = name;
			WorldX = worldX;
			WorldY = worldY;
			Ownername = ownername;
		}

	}
}
