using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SetCharacterRestrictionsMessage : Message
	{

		// Properties
		public ActorRestrictionsInformations Restrictions { get; set; }


		// Constructors
		public SetCharacterRestrictionsMessage() { }

		public SetCharacterRestrictionsMessage(ActorRestrictionsInformations restrictions = null)
		{
			Restrictions = restrictions;
		}

	}
}
