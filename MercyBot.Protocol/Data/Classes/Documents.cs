using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Documents : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("typeId")]
		public int TypeId { get; set; }
		[JsonProperty("titleId")]
		public string TitleId { get; set; }
		[JsonProperty("authorId")]
		public string AuthorId { get; set; }
		[JsonProperty("subTitleId")]
		public string SubTitleId { get; set; }
		[JsonProperty("contentId")]
		public string ContentId { get; set; }
		[JsonProperty("contentCSS")]
		public string ContentCSS { get; set; }


		//Constructor
		internal Documents() {}

	}
}
