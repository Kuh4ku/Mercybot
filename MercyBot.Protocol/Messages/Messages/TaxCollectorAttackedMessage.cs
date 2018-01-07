using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorAttackedMessage : Message
	{

		// Properties
		public uint FirstNameId { get; set; }
		public uint LastNameId { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public BasicGuildInformations Guild { get; set; }


		// Constructors
		public TaxCollectorAttackedMessage() { }

		public TaxCollectorAttackedMessage(uint firstNameId = 0, uint lastNameId = 0, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, BasicGuildInformations guild = null)
		{
			FirstNameId = firstNameId;
			LastNameId = lastNameId;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			Guild = guild;
		}

	}
}
