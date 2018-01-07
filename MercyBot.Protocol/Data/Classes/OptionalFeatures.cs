using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class OptionalFeatures : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("keyword")]
		public string Keyword { get; set; }


		//Constructor
		internal OptionalFeatures() {}

	}
}
