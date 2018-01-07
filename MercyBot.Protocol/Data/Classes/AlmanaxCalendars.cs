using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlmanaxCalendars : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descId")]
		public string DescId { get; set; }
		[JsonProperty("npcId")]
		public int NpcId { get; set; }


		//Constructor
		internal AlmanaxCalendars() {}

	}
}
