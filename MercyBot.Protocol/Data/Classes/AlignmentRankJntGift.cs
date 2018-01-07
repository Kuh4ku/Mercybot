using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentRankJntGift : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("gifts")]
		public List<int> Gifts { get; set; }
		[JsonProperty("parameters")]
		public List<int> Parameters { get; set; }
		[JsonProperty("levels")]
		public List<int> Levels { get; set; }


		//Constructor
		internal AlignmentRankJntGift() {}

	}
}
