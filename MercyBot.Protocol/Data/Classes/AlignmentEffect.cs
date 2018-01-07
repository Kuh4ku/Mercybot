using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentEffect : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("characteristicId")]
		public int CharacteristicId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }


		//Constructor
		internal AlignmentEffect() {}

	}
}
