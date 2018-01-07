using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class ItemSets : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("items")]
		public List<int> Items { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("bonusIsSecret")]
		public bool BonusIsSecret { get; set; }
		[JsonProperty("effects")]
		public List<List<dynamic>> Effects { get; set; }


		//Constructor
		internal ItemSets() {}

	}
}
