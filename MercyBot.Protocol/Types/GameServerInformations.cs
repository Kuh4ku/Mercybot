using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Types
{
	public class GameServerInformations
	{

		// Properties
		public uint Id { get; set; }
		public uint Status { get; set; }
		public uint Completion { get; set; }
		public bool IsSelectable { get; set; }
		public uint CharactersCount { get; set; }
		public double Date { get; set; }
        [JsonProperty("_name")]
        public string Name { get; set; }


		// Constructors
		public GameServerInformations() { }

		public GameServerInformations(uint id = 0, uint status = 1, uint completion = 0, bool isSelectable = false, uint charactersCount = 0, double date = 0, string name = null)
		{
			Id = id;
			Status = status;
			Completion = completion;
			IsSelectable = isSelectable;
			CharactersCount = charactersCount;
			Date = date;
            Name = name;
		}

	}
}
