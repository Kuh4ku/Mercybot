using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AllianceVersatileInformations
	{

		// Properties
		public uint AllianceId { get; set; }
		public uint NbGuilds { get; set; }
		public uint NbMembers { get; set; }
		public uint NbSubarea { get; set; }


		// Constructors
		public AllianceVersatileInformations() { }

		public AllianceVersatileInformations(uint allianceId = 0, uint nbGuilds = 0, uint nbMembers = 0, uint nbSubarea = 0)
		{
			AllianceId = allianceId;
			NbGuilds = nbGuilds;
			NbMembers = nbMembers;
			NbSubarea = nbSubarea;
		}

	}
}
