using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class AbuseReasons : IData
	{

		// Properties
		[JsonProperty("_abuseReasonId")]
		public int Id { get; set; }
		[JsonProperty("_mask")]
		public int Mask { get; set; }
		[JsonProperty("_reasonTextId")]
		public string ReasonTextId { get; set; }


		//Constructor
		internal AbuseReasons() {}

	}
}
