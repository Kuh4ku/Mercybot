using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Interactives : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("actionId")]
		public int ActionId { get; set; }
		[JsonProperty("displayTooltip")]
		public bool DisplayTooltip { get; set; }


		//Constructor
		internal Interactives() {}

	}
}
