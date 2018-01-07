using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Effects : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("characteristic")]
		public int Characteristic { get; set; }
		[JsonProperty("category")]
		public int Category { get; set; }
		[JsonProperty("operator")]
		public string Operator { get; set; }
		[JsonProperty("showInTooltip")]
		public bool ShowInTooltip { get; set; }
		[JsonProperty("useDice")]
		public bool UseDice { get; set; }
		[JsonProperty("forceMinMax")]
		public bool ForceMinMax { get; set; }
		[JsonProperty("boost")]
		public bool Boost { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("showInSet")]
		public bool ShowInSet { get; set; }
		[JsonProperty("bonusType")]
		public int BonusType { get; set; }
		[JsonProperty("useInFight")]
		public bool UseInFight { get; set; }
		[JsonProperty("effectPriority")]
		public int EffectPriority { get; set; }


		//Constructor
		internal Effects() {}

	}
}
