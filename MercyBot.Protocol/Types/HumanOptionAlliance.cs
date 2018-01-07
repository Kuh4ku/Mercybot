using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HumanOptionAlliance : HumanOption
	{

		// Properties
		public AllianceInformations AllianceInformations { get; set; }
		public uint Aggressable { get; set; }


		// Constructors
		public HumanOptionAlliance() { }

		public HumanOptionAlliance(AllianceInformations allianceInformations = null, uint aggressable = 0)
		{
			AllianceInformations = allianceInformations;
			Aggressable = aggressable;
		}

	}
}
