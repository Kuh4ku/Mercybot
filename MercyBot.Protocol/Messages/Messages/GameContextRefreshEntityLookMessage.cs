using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextRefreshEntityLookMessage : Message
	{

		// Properties
		public int Id { get; set; }
		public EntityLook Look { get; set; }


		// Constructors
		public GameContextRefreshEntityLookMessage() { }

		public GameContextRefreshEntityLookMessage(int id = 0, EntityLook look = null)
		{
			Id = id;
			Look = look;
		}

	}
}
