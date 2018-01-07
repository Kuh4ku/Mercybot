using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectedErrorMissingMapPackMessage : CharacterSelectedErrorMessage
	{

		// Properties
		public uint SubAreaId { get; set; }


		// Constructors
		public CharacterSelectedErrorMissingMapPackMessage() { }

		public CharacterSelectedErrorMissingMapPackMessage(uint subAreaId = 0)
		{
			SubAreaId = subAreaId;
		}

	}
}
