using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Recipes : IData
	{

		// Properties
		[JsonProperty("resultId")]
		public int Id { get; set; }
		[JsonProperty("resultLevel")]
		public int ResultLevel { get; set; }
		[JsonProperty("ingredientIds")]
		public List<int> IngredientIds { get; set; }
		[JsonProperty("quantities")]
		public List<int> Quantities { get; set; }


		//Constructor
		internal Recipes() {}

	}
}
