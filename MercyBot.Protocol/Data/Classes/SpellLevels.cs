using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SpellLevels : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("spellId")]
		public int SpellId { get; set; }
		[JsonProperty("spellBreed")]
		public int SpellBreed { get; set; }
		[JsonProperty("apCost")]
		public int ApCost { get; set; }
		[JsonProperty("minRange")]
		public int MinRange { get; set; }
		[JsonProperty("range")]
		public int Range { get; set; }
		[JsonProperty("castInLine")]
		public bool CastInLine { get; set; }
		[JsonProperty("castInDiagonal")]
		public bool CastInDiagonal { get; set; }
		[JsonProperty("castTestLos")]
		public bool CastTestLos { get; set; }
		[JsonProperty("criticalHitProbability")]
		public int CriticalHitProbability { get; set; }
		[JsonProperty("criticalFailureProbability")]
		public int CriticalFailureProbability { get; set; }
		[JsonProperty("needFreeCell")]
		public bool NeedFreeCell { get; set; }
		[JsonProperty("needTakenCell")]
		public bool NeedTakenCell { get; set; }
		[JsonProperty("needFreeTrapCell")]
		public bool NeedFreeTrapCell { get; set; }
		[JsonProperty("rangeCanBeBoosted")]
		public bool RangeCanBeBoosted { get; set; }
		[JsonProperty("maxStack")]
		public int MaxStack { get; set; }
		[JsonProperty("maxCastPerTurn")]
		public int MaxCastPerTurn { get; set; }
		[JsonProperty("maxCastPerTarget")]
		public int MaxCastPerTarget { get; set; }
		[JsonProperty("minCastInterval")]
		public int MinCastInterval { get; set; }
		[JsonProperty("initialCooldown")]
		public int InitialCooldown { get; set; }
		[JsonProperty("globalCooldown")]
		public int GlobalCooldown { get; set; }
		[JsonProperty("minPlayerLevel")]
		public int MinPlayerLevel { get; set; }
		[JsonProperty("criticalFailureEndsTurn")]
		public bool CriticalFailureEndsTurn { get; set; }
		[JsonProperty("hideEffects")]
		public bool HideEffects { get; set; }
		[JsonProperty("hidden")]
		public bool Hidden { get; set; }
		[JsonProperty("statesRequired")]
		public List<int> StatesRequired { get; set; }
		[JsonProperty("statesForbidden")]
		public List<int> StatesForbidden { get; set; }
		[JsonProperty("effects")]
		public List<JToken> Effects { get; set; }
		[JsonProperty("criticalEffect")]
		public List<dynamic> CriticalEffect { get; set; }
		[JsonProperty("canSummon")]
		public bool CanSummon { get; set; }
		[JsonProperty("canBomb")]
		public bool CanBomb { get; set; }


		//Constructor
		internal SpellLevels() {}

	}
}
