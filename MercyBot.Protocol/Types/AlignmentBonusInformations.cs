using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AlignmentBonusInformations
	{

		// Properties
		public uint Pctbonus { get; set; }
		public double Grademult { get; set; }


		// Constructors
		public AlignmentBonusInformations() { }

		public AlignmentBonusInformations(uint pctbonus = 0, double grademult = 0)
		{
			Pctbonus = pctbonus;
			Grademult = grademult;
		}

	}
}
