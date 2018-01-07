using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class CensoredWords : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("listId")]
		public int ListId { get; set; }
		[JsonProperty("language")]
		public string Language { get; set; }
		[JsonProperty("word")]
		public string Word { get; set; }
		[JsonProperty("deepLooking")]
		public bool DeepLooking { get; set; }


		//Constructor
		internal CensoredWords() {}

	}
}
