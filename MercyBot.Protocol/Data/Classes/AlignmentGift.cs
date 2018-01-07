using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AlignmentGift : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("effectId")]
		public int EffectId { get; set; }
		[JsonProperty("gfxId")]
		public int GfxId { get; set; }


		//Constructor
		internal AlignmentGift() {}

	}
}
