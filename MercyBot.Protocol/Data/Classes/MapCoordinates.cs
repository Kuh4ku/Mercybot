using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class MapCoordinates : IData
	{

		// Properties
		[JsonProperty("compressedCoords")]
		public int Id { get; set; }
		[JsonProperty("mapIds")]
		public List<int> MapIds { get; set; }


		//Constructor
		internal MapCoordinates() {}

	}
}
