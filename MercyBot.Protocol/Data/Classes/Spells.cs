using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Spells : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("typeId")]
		public int TypeId { get; set; }
		[JsonProperty("scriptParams")]
		public string ScriptParams { get; set; }
		[JsonProperty("scriptParamsCritical")]
		public string ScriptParamsCritical { get; set; }
		[JsonProperty("scriptId")]
		public int ScriptId { get; set; }
		[JsonProperty("scriptIdCritical")]
		public int ScriptIdCritical { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("spellLevels")]
		public List<int> SpellLevels { get; set; }


		//Constructor
		internal Spells() {}

	}
}
