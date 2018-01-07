using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Pets : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("foodItems")]
		public List<int> FoodItems { get; set; }
		[JsonProperty("foodTypes")]
		public List<object> FoodTypes { get; set; }


		//Constructor
		internal Pets() {}

	}
}
