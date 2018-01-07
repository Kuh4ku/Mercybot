using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class MapPositions : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("posX")]
		public int PosX { get; set; }
		[JsonProperty("posY")]
		public int PosY { get; set; }
		[JsonProperty("outdoor")]
		public bool Outdoor { get; set; }
		[JsonProperty("capabilities")]
		public int Capabilities { get; set; }
		[JsonProperty("sounds")]
		public List<dynamic> Sounds { get; set; }
		[JsonProperty("subAreaId")]
		public int SubAreaId { get; set; }
		[JsonProperty("worldMap")]
		public int WorldMap { get; set; }
		[JsonProperty("hasPriorityOnWorldmap")]
		public bool HasPriorityOnWorldmap { get; set; }


		//Constructor
		internal MapPositions() {}

	}
}
