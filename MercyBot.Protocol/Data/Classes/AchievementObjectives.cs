using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AchievementObjectives : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("achievementId")]
		public int AchievementId { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("criterion")]
		public string Criterion { get; set; }


		//Constructor
		internal AchievementObjectives() {}

	}
}
