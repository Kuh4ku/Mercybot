using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentBalance : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("startValue")]
		public int StartValue { get; set; }
		[JsonProperty("endValue")]
		public int EndValue { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }


		//Constructor
		internal AlignmentBalance() {}

	}
}
