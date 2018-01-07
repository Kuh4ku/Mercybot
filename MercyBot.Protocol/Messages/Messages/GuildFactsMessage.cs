using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFactsMessage : Message
	{

		// Properties
		public List<CharacterMinimalInformations> Members { get; set; }
		public GuildFactSheetInformations Infos { get; set; }
		public uint CreationDate { get; set; }
		public uint NbTaxCollectors { get; set; }
		public bool Enabled { get; set; }


		// Constructors
		public GuildFactsMessage() { }

		public GuildFactsMessage(GuildFactSheetInformations infos = null, uint creationDate = 0, uint nbTaxCollectors = 0, bool enabled = false, List<CharacterMinimalInformations> members = null)
		{
			Infos = infos;
			CreationDate = creationDate;
			NbTaxCollectors = nbTaxCollectors;
			Enabled = enabled;
			Members = members;
		}

	}
}
