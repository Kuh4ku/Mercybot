using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NicknameChoiceRequestMessage : Message
	{

		// Properties
		public string Nickname { get; set; }


		// Constructors
		public NicknameChoiceRequestMessage() { }

		public NicknameChoiceRequestMessage(string nickname = "")
		{
			Nickname = nickname;
		}

	}
}
