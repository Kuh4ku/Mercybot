using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class QuestStepRewards : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("stepId")]
		public int StepId { get; set; }
		[JsonProperty("levelMin")]
		public int LevelMin { get; set; }
		[JsonProperty("levelMax")]
		public int LevelMax { get; set; }
		[JsonProperty("itemsReward")]
		public List<List<int>> ItemsReward { get; set; }
		[JsonProperty("emotesReward")]
		public List<object> EmotesReward { get; set; }
		[JsonProperty("jobsReward")]
		public List<object> JobsReward { get; set; }
		[JsonProperty("spellsReward")]
		public List<object> SpellsReward { get; set; }


		//Constructor
		internal QuestStepRewards() {}

	}
}
