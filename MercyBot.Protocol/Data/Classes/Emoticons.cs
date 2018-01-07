using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Emoticons : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("shortcutId")]
		public string ShortcutId { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }
		[JsonProperty("defaultAnim")]
		public string DefaultAnim { get; set; }
		[JsonProperty("persistancy")]
		public bool Persistancy { get; set; }
		[JsonProperty("eight_directions")]
		public bool Eight_directions { get; set; }
		[JsonProperty("aura")]
		public bool Aura { get; set; }
		[JsonProperty("anims")]
		public List<string> Anims { get; set; }
		[JsonProperty("cooldown")]
		public int Cooldown { get; set; }
		[JsonProperty("duration")]
		public int Duration { get; set; }
		[JsonProperty("weight")]
		public int Weight { get; set; }


		//Constructor
		internal Emoticons() {}

	}
}
