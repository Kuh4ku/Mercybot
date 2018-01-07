using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceInsiderInfoMessage : Message
	{

		// Properties
		public List<GuildInsiderFactSheetInformations> Guilds { get; set; }
		public List<PrismSubareaEmptyInfo> Prisms { get; set; }
		public AllianceFactSheetInformations AllianceInfos { get; set; }


		// Constructors
		public AllianceInsiderInfoMessage() { }

		public AllianceInsiderInfoMessage(AllianceFactSheetInformations allianceInfos = null, List<GuildInsiderFactSheetInformations> guilds = null, List<PrismSubareaEmptyInfo> prisms = null)
		{
			AllianceInfos = allianceInfos;
			Guilds = guilds;
			Prisms = prisms;
		}

	}
}
