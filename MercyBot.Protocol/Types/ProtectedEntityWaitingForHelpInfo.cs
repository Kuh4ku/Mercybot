using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ProtectedEntityWaitingForHelpInfo
	{

		// Properties
		public int TimeLeftBeforeFight { get; set; }
		public int WaitTimeForPlacement { get; set; }
		public uint NbPositionForDefensors { get; set; }


		// Constructors
		public ProtectedEntityWaitingForHelpInfo() { }

		public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight = 0, int waitTimeForPlacement = 0, uint nbPositionForDefensors = 0)
		{
			TimeLeftBeforeFight = timeLeftBeforeFight;
			WaitTimeForPlacement = waitTimeForPlacement;
			NbPositionForDefensors = nbPositionForDefensors;
		}

	}
}
