using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
	{

		// Properties
		public string OwnerName { get; set; }
		public uint Level { get; set; }


		// Constructors
		public GameRolePlayMountInformations() { }

		public GameRolePlayMountInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "", string ownerName = "", uint level = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
			OwnerName = ownerName;
			Level = level;
		}

	}
}
