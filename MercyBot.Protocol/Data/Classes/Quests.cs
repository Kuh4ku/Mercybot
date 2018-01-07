using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Quests : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("isRepeatable")]
		public bool IsRepeatable { get; set; }
		[JsonProperty("repeatType")]
		public int RepeatType { get; set; }
		[JsonProperty("repeatLimit")]
		public int RepeatLimit { get; set; }
		[JsonProperty("isDungeonQuest")]
		public bool IsDungeonQuest { get; set; }
		[JsonProperty("levelMin")]
		public int LevelMin { get; set; }
		[JsonProperty("levelMax")]
		public int LevelMax { get; set; }
		[JsonProperty("stepIds")]
		public List<int> StepIds { get; set; }


		//Constructor
		internal Quests() {}

	}
}
