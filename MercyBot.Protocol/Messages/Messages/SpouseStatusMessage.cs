using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpouseStatusMessage : Message
	{

		// Properties
		public bool HasSpouse { get; set; }


		// Constructors
		public SpouseStatusMessage() { }

		public SpouseStatusMessage(bool hasSpouse = false)
		{
			HasSpouse = hasSpouse;
		}

	}
}
