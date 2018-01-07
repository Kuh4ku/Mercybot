using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountSterilizeFromPaddockMessage : Message
	{

		// Properties
		public string Name { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public string Sterilizator { get; set; }


		// Constructors
		public ExchangeMountSterilizeFromPaddockMessage() { }

		public ExchangeMountSterilizeFromPaddockMessage(string name = "", int worldX = 0, int worldY = 0, string sterilizator = "")
		{
			Name = name;
			WorldX = worldX;
			WorldY = worldY;
			Sterilizator = sterilizator;
		}

	}
}
