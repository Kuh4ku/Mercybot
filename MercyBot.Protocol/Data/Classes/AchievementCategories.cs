using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AchievementCategories : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("parentId")]
		public int ParentId { get; set; }
		[JsonProperty("icon")]
		public string Icon { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }
		[JsonProperty("color")]
		public string Color { get; set; }
		[JsonProperty("achievementIds")]
		public List<int> AchievementIds { get; set; }


		//Constructor
		internal AchievementCategories() {}

	}
}
