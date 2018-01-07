using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SoundBones : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("keys")]
		public List<string> Keys { get; set; }
		[JsonProperty("values")]
		public List<List<dynamic>> Values { get; set; }


		//Constructor
		internal SoundBones() {}

	}
}
