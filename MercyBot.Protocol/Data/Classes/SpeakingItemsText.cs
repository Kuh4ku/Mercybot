using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SpeakingItemsText : IData
	{

		// Properties
		[JsonProperty("textId")]
		public int Id { get; set; }
		[JsonProperty("textProba")]
		public int TextProba { get; set; }
		[JsonProperty("textStringId")]
		public string TextStringId { get; set; }
		[JsonProperty("textLevel")]
		public int TextLevel { get; set; }
		[JsonProperty("textSound")]
		public int TextSound { get; set; }
		[JsonProperty("textRestriction")]
		public string TextRestriction { get; set; }


		//Constructor
		internal SpeakingItemsText() {}

	}
}
