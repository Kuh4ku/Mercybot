using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class EmblemBackgrounds : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }


		//Constructor
		internal EmblemBackgrounds() {}

	}
}
