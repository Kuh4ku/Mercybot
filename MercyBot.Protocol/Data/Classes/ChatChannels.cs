using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class ChatChannels : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("descriptionId")]
		public string DescriptionId { get; set; }
		[JsonProperty("shortcut")]
		public string Shortcut { get; set; }
		[JsonProperty("shortcutKey")]
		public string ShortcutKey { get; set; }
		[JsonProperty("isPrivate")]
		public bool IsPrivate { get; set; }
		[JsonProperty("allowObjects")]
		public bool AllowObjects { get; set; }


		//Constructor
		internal ChatChannels() {}

	}
}
