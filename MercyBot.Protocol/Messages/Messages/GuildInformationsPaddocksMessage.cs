using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInformationsPaddocksMessage : Message
	{

		// Properties
		public List<PaddockContentInformations> PaddocksInformations { get; set; }
		public uint NbPaddockMax { get; set; }


		// Constructors
		public GuildInformationsPaddocksMessage() { }

		public GuildInformationsPaddocksMessage(uint nbPaddockMax = 0, List<PaddockContentInformations> paddocksInformations = null)
		{
			NbPaddockMax = nbPaddockMax;
			PaddocksInformations = paddocksInformations;
		}

	}
}
