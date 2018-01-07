using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameMapChangeOrientationsMessage : Message
	{

		// Properties
		public List<ActorOrientation> Orientations { get; set; }


		// Constructors
		public GameMapChangeOrientationsMessage() { }

		public GameMapChangeOrientationsMessage(List<ActorOrientation> orientations = null)
		{
			Orientations = orientations;
		}

	}
}
