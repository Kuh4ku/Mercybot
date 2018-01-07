using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentTitles : IData
	{

		// Properties
		[JsonProperty("sideId")]
		public int Id { get; set; }
		[JsonProperty("namesId")]
		public List<string> NamesId { get; set; }
		[JsonProperty("shortsId")]
		public List<string> ShortsId { get; set; }


		//Constructor
		internal AlignmentTitles() {}

	}
}
