using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountFreeFromPaddockMessage : Message
	{

		// Properties
		public string Name { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public string Liberator { get; set; }


		// Constructors
		public ExchangeMountFreeFromPaddockMessage() { }

		public ExchangeMountFreeFromPaddockMessage(string name = "", int worldX = 0, int worldY = 0, string liberator = "")
		{
			Name = name;
			WorldX = worldX;
			WorldY = worldY;
			Liberator = liberator;
		}

	}
}
