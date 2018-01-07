using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HumanOptionFollowers : HumanOption
	{

		// Properties
		public List<IndexedEntityLook> FollowingCharactersLook { get; set; }


		// Constructors
		public HumanOptionFollowers() { }

		public HumanOptionFollowers(List<IndexedEntityLook> followingCharactersLook = null)
		{
			FollowingCharactersLook = followingCharactersLook;
		}

	}
}
