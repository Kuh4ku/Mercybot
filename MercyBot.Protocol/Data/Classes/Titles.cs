using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Titles : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameMaleId")]
		public string NameMaleId { get; set; }
		[JsonProperty("nameFemaleId")]
		public string NameFemaleId { get; set; }
		[JsonProperty("visible")]
		public bool Visible { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }


		//Constructor
		internal Titles() {}

	}
}
