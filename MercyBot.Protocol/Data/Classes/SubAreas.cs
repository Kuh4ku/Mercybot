using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SubAreas : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("areaId")]
		public int AreaId { get; set; }
		[JsonProperty("ambientSounds")]
		public List<dynamic> AmbientSounds { get; set; }
		[JsonProperty("mapIds")]
		public List<int> MapIds { get; set; }
		[JsonProperty("bounds")]
		public dynamic Bounds { get; set; }
		[JsonProperty("shape")]
		public List<int> Shape { get; set; }
		[JsonProperty("customWorldMap")]
		public List<object> CustomWorldMap { get; set; }
		[JsonProperty("packId")]
		public int PackId { get; set; }
		[JsonProperty("level")]
		public int Level { get; set; }
		[JsonProperty("isConquestVillage")]
		public bool IsConquestVillage { get; set; }
		[JsonProperty("displayOnWorldMap")]
		public bool DisplayOnWorldMap { get; set; }
		[JsonProperty("monsters")]
		public List<int> Monsters { get; set; }
		[JsonProperty("entranceMapIds")]
		public List<object> EntranceMapIds { get; set; }
		[JsonProperty("exitMapIds")]
		public List<object> ExitMapIds { get; set; }
		[JsonProperty("capturable")]
		public bool Capturable { get; set; }


		//Constructor
		internal SubAreas() {}

	}
}
