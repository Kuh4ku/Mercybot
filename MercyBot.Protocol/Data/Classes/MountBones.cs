using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class MountBones : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }


		//Constructor
		internal MountBones() {}

	}
}
