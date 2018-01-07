using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AlignmentSubAreaUpdateMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public int Side { get; set; }
		public bool Quiet { get; set; }


		// Constructors
		public AlignmentSubAreaUpdateMessage() { }

		public AlignmentSubAreaUpdateMessage(uint subAreaId = 0, int side = 0, bool quiet = false)
		{
			SubAreaId = subAreaId;
			Side = side;
			Quiet = quiet;
		}

	}
}
