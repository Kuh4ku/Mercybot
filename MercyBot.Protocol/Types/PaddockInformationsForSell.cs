using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockInformationsForSell
	{

		// Properties
		public string GuildOwner { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public uint SubAreaId { get; set; }
		public int NbMount { get; set; }
		public int NbObject { get; set; }
		public uint Price { get; set; }


		// Constructors
		public PaddockInformationsForSell() { }

		public PaddockInformationsForSell(string guildOwner = "", int worldX = 0, int worldY = 0, uint subAreaId = 0, int nbMount = 0, int nbObject = 0, uint price = 0)
		{
			GuildOwner = guildOwner;
			WorldX = worldX;
			WorldY = worldY;
			SubAreaId = subAreaId;
			NbMount = nbMount;
			NbObject = nbObject;
			Price = price;
		}

	}
}
