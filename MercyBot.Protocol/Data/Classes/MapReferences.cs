using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class MapReferences : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("mapId")]
		public int MapId { get; set; }
		[JsonProperty("cellId")]
		public int CellId { get; set; }


		//Constructor
		internal MapReferences() {}

	}
}
