using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Hints : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("gfx")]
		public int Gfx { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("mapId")]
		public int MapId { get; set; }
		[JsonProperty("realMapId")]
		public int RealMapId { get; set; }
		[JsonProperty("x")]
		public int X { get; set; }
		[JsonProperty("y")]
		public int Y { get; set; }
		[JsonProperty("outdoor")]
		public bool Outdoor { get; set; }
		[JsonProperty("subareaId")]
		public int SubareaId { get; set; }
		[JsonProperty("worldMapId")]
		public int WorldMapId { get; set; }


		//Constructor
		internal Hints() {}

	}
}
