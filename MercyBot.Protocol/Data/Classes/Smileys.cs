using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Smileys : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }
		[JsonProperty("gfxId")]
		public string GfxId { get; set; }
		[JsonProperty("forPlayers")]
		public bool ForPlayers { get; set; }
		[JsonProperty("triggers")]
		public List<string> Triggers { get; set; }


		//Constructor
		internal Smileys() {}

	}
}
