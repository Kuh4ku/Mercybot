using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AchievementRewards : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("achievementId")]
		public int AchievementId { get; set; }
		[JsonProperty("levelMin")]
		public int LevelMin { get; set; }
		[JsonProperty("levelMax")]
		public int LevelMax { get; set; }
		[JsonProperty("itemsReward")]
		public List<int> ItemsReward { get; set; }
		[JsonProperty("itemsQuantityReward")]
		public List<int> ItemsQuantityReward { get; set; }
		[JsonProperty("emotesReward")]
		public List<object> EmotesReward { get; set; }
		[JsonProperty("spellsReward")]
		public List<object> SpellsReward { get; set; }
		[JsonProperty("titlesReward")]
		public List<object> TitlesReward { get; set; }
		[JsonProperty("ornamentsReward")]
		public List<object> OrnamentsReward { get; set; }


		//Constructor
		internal AchievementRewards() {}

	}
}
