using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class ServerCommunities : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("defaultCountries")]
		public List<string> DefaultCountries { get; set; }
		[JsonProperty("shortId")]
		public string ShortId { get; set; }


		//Constructor
		internal ServerCommunities() {}

	}
}
