using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class NpcMessages : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("messageId")]
		public string MessageId { get; set; }


		//Constructor
		internal NpcMessages() {}

	}
}
