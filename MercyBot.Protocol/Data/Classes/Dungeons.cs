using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Dungeons : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("optimalPlayerLevel")]
		public int OptimalPlayerLevel { get; set; }
		[JsonProperty("mapIds")]
		public List<int> MapIds { get; set; }
		[JsonProperty("entranceMapId")]
		public int EntranceMapId { get; set; }
		[JsonProperty("exitMapId")]
		public int ExitMapId { get; set; }


		//Constructor
		internal Dungeons() {}

	}
}
