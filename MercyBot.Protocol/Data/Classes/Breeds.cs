using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Breeds : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("shortNameId")]
		public string ShortNameId { get; set; }
		[JsonProperty("longNameId")]
		public string LongNameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("gameplayDescriptionId")]
		public string GameplayDescriptionId { get; set; }
		[JsonProperty("maleLook")]
		public string MaleLook { get; set; }
		[JsonProperty("femaleLook")]
		public string FemaleLook { get; set; }
		[JsonProperty("creatureBonesId")]
		public int CreatureBonesId { get; set; }
		[JsonProperty("maleArtwork")]
		public int MaleArtwork { get; set; }
		[JsonProperty("femaleArtwork")]
		public int FemaleArtwork { get; set; }
		[JsonProperty("statsPointsForStrength")]
		public List<List<int>> StatsPointsForStrength { get; set; }
		[JsonProperty("statsPointsForIntelligence")]
		public List<List<int>> StatsPointsForIntelligence { get; set; }
		[JsonProperty("statsPointsForChance")]
		public List<List<int>> StatsPointsForChance { get; set; }
		[JsonProperty("statsPointsForAgility")]
		public List<List<int>> StatsPointsForAgility { get; set; }
		[JsonProperty("statsPointsForVitality")]
		public List<List<int>> StatsPointsForVitality { get; set; }
		[JsonProperty("statsPointsForWisdom")]
		public List<List<int>> StatsPointsForWisdom { get; set; }
		[JsonProperty("breedSpellsId")]
		public List<int> BreedSpellsId { get; set; }
		[JsonProperty("maleColors")]
		public List<int> MaleColors { get; set; }
		[JsonProperty("femaleColors")]
		public List<int> FemaleColors { get; set; }


		//Constructor
		internal Breeds() {}

	}
}
