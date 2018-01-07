using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SpellBombs : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("chainReactionSpellId")]
		public int ChainReactionSpellId { get; set; }
		[JsonProperty("explodSpellId")]
		public int ExplodSpellId { get; set; }
		[JsonProperty("wallId")]
		public int WallId { get; set; }
		[JsonProperty("instantSpellId")]
		public int InstantSpellId { get; set; }
		[JsonProperty("comboCoeff")]
		public int ComboCoeff { get; set; }


		//Constructor
		internal SpellBombs() {}

	}
}
