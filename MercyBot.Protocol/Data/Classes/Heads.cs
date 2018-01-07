using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Heads : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("skins")]
		public string Skins { get; set; }
		[JsonProperty("assetId")]
		public string AssetId { get; set; }
		[JsonProperty("breed")]
		public int Breed { get; set; }
		[JsonProperty("gender")]
		public int Gender { get; set; }
		[JsonProperty("label")]
		public string Label { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }


		//Constructor
		internal Heads() {}

	}
}
