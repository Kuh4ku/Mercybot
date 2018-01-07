using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInformationsGeneralMessage : Message
	{

		// Properties
		public bool Enabled { get; set; }
		public bool AbandonnedPaddock { get; set; }
		public uint Level { get; set; }
		public double ExpLevelFloor { get; set; }
		public double Experience { get; set; }
		public double ExpNextLevelFloor { get; set; }
		public uint CreationDate { get; set; }


		// Constructors
		public GuildInformationsGeneralMessage() { }

		public GuildInformationsGeneralMessage(bool enabled = false, bool abandonnedPaddock = false, uint level = 0, double expLevelFloor = 0, double experience = 0, double expNextLevelFloor = 0, uint creationDate = 0)
		{
			Enabled = enabled;
			AbandonnedPaddock = abandonnedPaddock;
			Level = level;
			ExpLevelFloor = expLevelFloor;
			Experience = experience;
			ExpNextLevelFloor = expNextLevelFloor;
			CreationDate = creationDate;
		}

	}
}
