using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class SoundUi : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("uiName")]
		public string UiName { get; set; }
		[JsonProperty("openFile")]
		public string OpenFile { get; set; }
		[JsonProperty("closeFile")]
		public string CloseFile { get; set; }
		[JsonProperty("subElements")]
		public List<object> SubElements { get; set; }


		//Constructor
		internal SoundUi() {}

	}
}
