using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class Skills : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nameId")]
		public string NameId { get; set; }
		[JsonProperty("parentJobId")]
		public int ParentJobId { get; set; }
		[JsonProperty("isForgemagus")]
		public bool IsForgemagus { get; set; }
		[JsonProperty("modifiableItemType")]
		public int ModifiableItemType { get; set; }
		[JsonProperty("gatheredRessourceItem")]
		public int GatheredRessourceItem { get; set; }
		[JsonProperty("craftableItemIds")]
		public List<object> CraftableItemIds { get; set; }
		[JsonProperty("interactiveId")]
		public int InteractiveId { get; set; }
		[JsonProperty("useAnimation")]
		public string UseAnimation { get; set; }
		[JsonProperty("isRepair")]
		public bool IsRepair { get; set; }
		[JsonProperty("cursor")]
		public int Cursor { get; set; }
		[JsonProperty("availableInHouse")]
		public bool AvailableInHouse { get; set; }
		[JsonProperty("levelMin")]
		public int LevelMin { get; set; }


		//Constructor
		internal Skills() {}

	}
}
