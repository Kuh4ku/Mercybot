using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class RideFood : IData
	{

		// Properties
		[JsonProperty("gid")]
		public int Id { get; set; }
		[JsonProperty("typeId")]
		public int TypeId { get; set; }


		//Constructor
		internal RideFood() {}

	}
}
