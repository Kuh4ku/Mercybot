using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Monsters : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("gfxId")]
		public int GfxId { get; set; }
		[JsonProperty("race")]
		public int Race { get; set; }
		[JsonProperty("grades")]
		public List<dynamic> Grades { get; set; }
		[JsonProperty("look")]
		public string Look { get; set; }
		[JsonProperty("useSummonSlot")]
		public bool UseSummonSlot { get; set; }
		[JsonProperty("useBombSlot")]
		public bool UseBombSlot { get; set; }
		[JsonProperty("canPlay")]
		public bool CanPlay { get; set; }
		[JsonProperty("animFunList")]
		public List<object> AnimFunList { get; set; }
		[JsonProperty("canTackle")]
		public bool CanTackle { get; set; }
		[JsonProperty("isBoss")]
		public bool IsBoss { get; set; }
		[JsonProperty("drops")]
		public List<object> Drops { get; set; }
		[JsonProperty("subareas")]
		public List<object> Subareas { get; set; }
		[JsonProperty("spells")]
		public List<object> Spells { get; set; }
		[JsonProperty("favoriteSubareaId")]
		public int FavoriteSubareaId { get; set; }
		[JsonProperty("isMiniBoss")]
		public bool IsMiniBoss { get; set; }
		[JsonProperty("isQuestMonster")]
		public bool IsQuestMonster { get; set; }
		[JsonProperty("correspondingMiniBossId")]
		public int CorrespondingMiniBossId { get; set; }


		//Constructor
		internal Monsters() {}

	}
}
