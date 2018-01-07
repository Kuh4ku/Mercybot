using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Achievements : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("points")]
		public int Points { get; set; }
		[JsonProperty("level")]
		public int Level { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }
		[JsonProperty("kamasRatio")]
		public float KamasRatio { get; set; }
		[JsonProperty("experienceRatio")]
		public float ExperienceRatio { get; set; }
		[JsonProperty("kamasScaleWithPlayerLevel")]
		public bool KamasScaleWithPlayerLevel { get; set; }
		[JsonProperty("objectiveIds")]
		public List<int> ObjectiveIds { get; set; }
		[JsonProperty("rewardIds")]
		public List<object> RewardIds { get; set; }


		//Constructor
		internal Achievements() {}

	}
}
