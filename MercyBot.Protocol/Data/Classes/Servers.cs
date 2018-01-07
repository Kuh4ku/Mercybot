using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Servers : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("commentId")]
		public string CommentId { get; set; }
		[JsonProperty("openingDate")]
		public long OpeningDate { get; set; }
		[JsonProperty("language")]
		public string Language { get; set; }
		[JsonProperty("populationId")]
		public int PopulationId { get; set; }
		[JsonProperty("gameTypeId")]
		public int GameTypeId { get; set; }
		[JsonProperty("communityId")]
		public int CommunityId { get; set; }
		[JsonProperty("restrictedToLanguages")]
		public List<object> RestrictedToLanguages { get; set; }


		//Constructor
		internal Servers() {}

	}
}
