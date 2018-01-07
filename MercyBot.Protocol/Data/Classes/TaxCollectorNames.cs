using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class TaxCollectorNames : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }


		//Constructor
		internal TaxCollectorNames() {}

	}
}
