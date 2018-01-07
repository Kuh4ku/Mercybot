using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class QuestSteps : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("questId")]
		public int QuestId { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("dialogId")]
		public int DialogId { get; set; }
		[JsonProperty("optimalLevel")]
		public int OptimalLevel { get; set; }
		[JsonProperty("duration")]
		public int Duration { get; set; }
		[JsonProperty("kamasScaleWithPlayerLevel")]
		public bool KamasScaleWithPlayerLevel { get; set; }
		[JsonProperty("kamasRatio")]
		public int KamasRatio { get; set; }
		[JsonProperty("xpRatio")]
		public int XpRatio { get; set; }
		[JsonProperty("objectiveIds")]
		public List<int> ObjectiveIds { get; set; }
		[JsonProperty("rewardsIds")]
		public List<int> RewardsIds { get; set; }


		//Constructor
		internal QuestSteps() {}

	}
}
