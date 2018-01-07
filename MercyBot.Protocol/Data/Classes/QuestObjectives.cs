using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class QuestObjectives : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("stepId")]
		public int StepId { get; set; }
		[JsonProperty("typeId")]
		public int TypeId { get; set; }
		[JsonProperty("mapId")]
		public int MapId { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("dialogId")]
		public int DialogId { get; set; }
		[JsonProperty("parameters")]
		public List<int> Parameters { get; set; }
		[JsonProperty("coords")]
		public dynamic Coords { get; set; }


		//Constructor
		internal QuestObjectives() {}

	}
}
