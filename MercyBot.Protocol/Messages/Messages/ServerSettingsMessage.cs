using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ServerSettingsMessage : Message
	{

		// Properties
		public string Lang { get; set; }
		public uint Community { get; set; }
		public uint GameType { get; set; }


		// Constructors
		public ServerSettingsMessage() { }

		public ServerSettingsMessage(string lang = "", uint community = 0, uint gameType = 0)
		{
			Lang = lang;
			Community = community;
			GameType = gameType;
		}

	}
}
