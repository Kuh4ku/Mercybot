using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Url : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("browserId")]
		public int BrowserId { get; set; }
		[JsonProperty("url")]
		public string _Url { get; set; }
		[JsonProperty("param")]
		public string Param { get; set; }
		[JsonProperty("method")]
		public string Method { get; set; }


		//Constructor
		internal Url() {}

	}
}
