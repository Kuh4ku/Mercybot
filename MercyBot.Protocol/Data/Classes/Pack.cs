using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Pack : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("hasSubAreas")]
		public bool HasSubAreas { get; set; }


		//Constructor
		internal Pack() {}

	}
}
