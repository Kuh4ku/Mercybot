using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentRank : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("orderId")]
		public int OrderId { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("minimumAlignment")]
		public int MinimumAlignment { get; set; }
		[JsonProperty("objectsStolen")]
		public int ObjectsStolen { get; set; }
		[JsonProperty("gifts")]
		public List<object> Gifts { get; set; }


		//Constructor
		internal AlignmentRank() {}

	}
}
