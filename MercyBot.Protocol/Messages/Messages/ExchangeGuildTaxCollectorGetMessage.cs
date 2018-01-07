using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeGuildTaxCollectorGetMessage : Message
	{

		// Properties
		public List<ObjectItemQuantity> ObjectsInfos { get; set; }
		public string CollectorName { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public string UserName { get; set; }
		public double Experience { get; set; }


		// Constructors
		public ExchangeGuildTaxCollectorGetMessage() { }

		public ExchangeGuildTaxCollectorGetMessage(string collectorName = "", int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, string userName = "", double experience = 0, List<ObjectItemQuantity> objectsInfos = null)
		{
			CollectorName = collectorName;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			UserName = userName;
			Experience = experience;
			ObjectsInfos = objectsInfos;
		}

	}
}
