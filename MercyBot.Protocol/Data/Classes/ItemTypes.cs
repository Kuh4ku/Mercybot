using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class ItemTypes : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("superTypeId")]
		public int SuperTypeId { get; set; }
		[JsonProperty("plural")]
		public bool Plural { get; set; }
		[JsonProperty("gender")]
		public int Gender { get; set; }
		[JsonProperty("rawZone")]
		public string RawZone { get; set; }
		[JsonProperty("needUseConfirm")]
		public bool NeedUseConfirm { get; set; }


		//Constructor
		internal ItemTypes() {}

	}
}
