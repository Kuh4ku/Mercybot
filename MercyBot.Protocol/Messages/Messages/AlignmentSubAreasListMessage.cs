using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AlignmentSubAreasListMessage : Message
	{

		// Properties
		public List<int> AngelsSubAreas { get; set; }
		public List<int> EvilsSubAreas { get; set; }


		// Constructors
		public AlignmentSubAreasListMessage() { }

		public AlignmentSubAreasListMessage(List<int> angelsSubAreas = null, List<int> evilsSubAreas = null)
		{
			AngelsSubAreas = angelsSubAreas;
			EvilsSubAreas = evilsSubAreas;
		}

	}
}
