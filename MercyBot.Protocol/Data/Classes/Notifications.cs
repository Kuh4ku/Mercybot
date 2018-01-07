using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Notifications : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("titleId")]
		public string TitleId { get; set; }
		[JsonProperty("messageId")]
		public string MessageId { get; set; }
		[JsonProperty("iconId")]
		public int IconId { get; set; }
		[JsonProperty("typeId")]
		public int TypeId { get; set; }
		[JsonProperty("trigger")]
		public string Trigger { get; set; }


		//Constructor
		internal Notifications() {}

	}
}
