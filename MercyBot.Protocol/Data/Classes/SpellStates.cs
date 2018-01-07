using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SpellStates : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("preventsSpellCast")]
		public bool PreventsSpellCast { get; set; }
		[JsonProperty("preventsFight")]
		public bool PreventsFight { get; set; }
		[JsonProperty("critical")]
		public bool Critical { get; set; }


		//Constructor
		internal SpellStates() {}

	}
}
