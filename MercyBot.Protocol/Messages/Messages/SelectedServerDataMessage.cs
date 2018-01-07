using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Messages
{
	public class SelectedServerDataMessage : Message
	{

		// Properties
		public int ServerId { get; set; }
		public string Address { get; set; }
		public uint Port { get; set; }
		public bool CanCreateNewCharacter { get; set; }
		public string Ticket { get; set; }
        [JsonProperty("_access")]
        public string Access { get; set; }


		// Constructors
		public SelectedServerDataMessage() { }

		public SelectedServerDataMessage(int serverId = 0, string address = "", uint port = 0, bool canCreateNewCharacter = false, string ticket = "")
		{
			ServerId = serverId;
			Address = address;
			Port = port;
			CanCreateNewCharacter = canCreateNewCharacter;
			Ticket = ticket;
		}

	}
}
