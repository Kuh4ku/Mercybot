using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Items : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("typeId")]
		public int TypeId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("level")]
		public int Level { get; set; }
		[JsonProperty("realWeight")]
		public int RealWeight { get; set; }
		[JsonProperty("cursed")]
		public bool Cursed { get; set; }
		[JsonProperty("useAnimationId")]
		public int UseAnimationId { get; set; }
		[JsonProperty("usable")]
		public bool Usable { get; set; }
		[JsonProperty("targetable")]
		public bool Targetable { get; set; }
		[JsonProperty("exchangeable")]
		public bool Exchangeable { get; set; }
		[JsonProperty("price")]
		public int Price { get; set; }
		[JsonProperty("twoHanded")]
		public bool TwoHanded { get; set; }
		[JsonProperty("etheral")]
		public bool Etheral { get; set; }
		[JsonProperty("itemSetId")]
		public int ItemSetId { get; set; }
		[JsonProperty("criteria")]
		public string Criteria { get; set; }
		[JsonProperty("criteriaTarget")]
		public string CriteriaTarget { get; set; }
		[JsonProperty("hideEffects")]
		public bool HideEffects { get; set; }
		[JsonProperty("enhanceable")]
		public bool Enhanceable { get; set; }
		[JsonProperty("nonUsableOnAnother")]
		public bool NonUsableOnAnother { get; set; }
		[JsonProperty("appearanceId")]
		public int AppearanceId { get; set; }
		[JsonProperty("secretRecipe")]
		public bool SecretRecipe { get; set; }
		[JsonProperty("recipeSlots")]
		public int RecipeSlots { get; set; }
		[JsonProperty("recipeIds")]
		public List<object> RecipeIds { get; set; }
		[JsonProperty("dropMonsterIds")]
		public List<object> DropMonsterIds { get; set; }
		[JsonProperty("bonusIsSecret")]
		public bool BonusIsSecret { get; set; }
		[JsonProperty("possibleEffects")]
		public List<dynamic> PossibleEffects { get; set; }
		[JsonProperty("favoriteSubAreas")]
		public List<object> FavoriteSubAreas { get; set; }
		[JsonProperty("favoriteSubAreasBonus")]
		public int FavoriteSubAreasBonus { get; set; }
        [JsonProperty("range")]
        public int Range { get; set; }


		//Constructor
		internal Items() {}

	}
}
