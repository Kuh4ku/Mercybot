using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class ExternalNotifications : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("categoryId")]
		public int CategoryId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("colorId")]
		public int ColorId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("defaultEnable")]
		public bool DefaultEnable { get; set; }
		[JsonProperty("defaultSound")]
		public bool DefaultSound { get; set; }
		[JsonProperty("defaultMultiAccount")]
		public bool DefaultMultiAccount { get; set; }
		[JsonProperty("defaultNotify")]
		public bool DefaultNotify { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("messageId")]
		public string MessageId { get; set; }


		//Constructor
		internal ExternalNotifications() {}

	}
}
