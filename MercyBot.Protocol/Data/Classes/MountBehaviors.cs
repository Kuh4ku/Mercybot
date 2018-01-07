using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class MountBehaviors : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }


		//Constructor
		internal MountBehaviors() {}

	}
}
