using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class MonsterRaces : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("superRaceId")]
		public int SuperRaceId { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("monsters")]
		public List<int> Monsters { get; set; }


		//Constructor
		internal MonsterRaces() {}

	}
}
