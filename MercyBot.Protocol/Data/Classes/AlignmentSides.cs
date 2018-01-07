using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentSides : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("canConquest")]
		public bool CanConquest { get; set; }


		//Constructor
		internal AlignmentSides() {}

	}
}
