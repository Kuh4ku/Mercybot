using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Appearances : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("data")]
		public string Data { get; set; }


		//Constructor
		internal Appearances() {}

	}
}
