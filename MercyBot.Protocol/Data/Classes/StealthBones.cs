using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class StealthBones : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }


		//Constructor
		internal StealthBones() {}

	}
}
