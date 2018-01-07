using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LockableStateUpdateAbstractMessage : Message
	{

		// Properties
		public bool Locked { get; set; }


		// Constructors
		public LockableStateUpdateAbstractMessage() { }

		public LockableStateUpdateAbstractMessage(bool locked = false)
		{
			Locked = locked;
		}

	}
}
