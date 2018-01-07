using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Areas : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("superAreaId")]
		public int SuperAreaId { get; set; }
		[JsonProperty("containHouses")]
		public bool ContainHouses { get; set; }
		[JsonProperty("containPaddocks")]
		public bool ContainPaddocks { get; set; }
		[JsonProperty("bounds")]
		public dynamic Bounds { get; set; }


		//Constructor
		internal Areas() {}

	}
}
