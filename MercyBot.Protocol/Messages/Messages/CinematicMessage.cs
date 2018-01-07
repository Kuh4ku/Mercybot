using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CinematicMessage : Message
	{

		// Properties
		public uint CinematicId { get; set; }


		// Constructors
		public CinematicMessage() { }

		public CinematicMessage(uint cinematicId = 0)
		{
			CinematicId = cinematicId;
		}

	}
}
