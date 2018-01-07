using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Ornaments : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("visible")]
		public bool Visible { get; set; }
		[JsonProperty("assetId")]
		public int AssetId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("rarity")]
		public int Rarity { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }


		//Constructor
		internal Ornaments() {}

	}
}
