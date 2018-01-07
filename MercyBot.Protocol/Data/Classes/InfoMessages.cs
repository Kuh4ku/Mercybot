using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class InfoMessages : IData
	{

		// Properties
		[JsonProperty("typeId")]
		public int TypeId { get; set; }
		[JsonProperty("messageId")]
		public int Id { get; set; }
		[JsonProperty("textId")]
		public string TextId { get; set; }


		//Constructor
		internal InfoMessages() {}

	}
}
