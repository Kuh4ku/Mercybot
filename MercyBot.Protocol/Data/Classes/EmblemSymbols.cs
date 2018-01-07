using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class EmblemSymbols : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("skinId")]
		public int SkinId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("colorizable")]
		public bool Colorizable { get; set; }


		//Constructor
		internal EmblemSymbols() {}

	}
}
