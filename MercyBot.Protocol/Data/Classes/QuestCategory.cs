using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class QuestCategory : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("order")]
		public int Order { get; set; }
		[JsonProperty("questIds")]
		public List<int> QuestIds { get; set; }


		//Constructor
		internal QuestCategory() {}

	}
}
