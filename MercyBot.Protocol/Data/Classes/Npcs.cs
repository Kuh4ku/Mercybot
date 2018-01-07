using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Npcs : IData
	{

		// Properties
		[JsonProperty("_type")]
		public string Type { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("dialogMessages")]
		public List<List<int>> DialogMessages { get; set; }
		[JsonProperty("dialogReplies")]
		public List<List<int>> DialogReplies { get; set; }
		[JsonProperty("actions")]
		public List<int> Actions { get; set; }
        [JsonProperty("actionsName")]
        public List<string> ActionsName { get; set; }
		[JsonProperty("gender")]
		public int Gender { get; set; }
		[JsonProperty("look")]
		public string Look { get; set; }
		[JsonProperty("animFunList")]
		public List<object> AnimFunList { get; set; }


		//Constructor
		internal Npcs() {}

	}
}
