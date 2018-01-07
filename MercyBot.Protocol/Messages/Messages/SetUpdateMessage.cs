using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SetUpdateMessage : Message
	{

		// Properties
		public List<uint> SetObjects { get; set; }
		public List<ObjectEffect> SetEffects { get; set; }
		public uint SetId { get; set; }


		// Constructors
		public SetUpdateMessage() { }

		public SetUpdateMessage(uint setId = 0, List<uint> setObjects = null, List<ObjectEffect> setEffects = null)
		{
			SetId = setId;
			SetObjects = setObjects;
			SetEffects = setEffects;
		}

	}
}
