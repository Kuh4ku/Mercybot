using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CompassUpdateMessage : Message
	{

		// Properties
		public uint Type { get; set; }
		public MapCoordinates Coords { get; set; }


		// Constructors
		public CompassUpdateMessage() { }

		public CompassUpdateMessage(uint type = 0, MapCoordinates coords = null)
		{
			Type = type;
			Coords = coords;
		}

	}
}
