using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
	{

		// Properties
		public List<uint> Skills { get; set; }
		public uint PlayerId { get; set; }


		// Constructors
		public JobMultiCraftAvailableSkillsMessage() { }

		public JobMultiCraftAvailableSkillsMessage(bool enabled = false, uint playerId = 0, List<uint> skills = null)
		{
			Enabled = enabled;
			PlayerId = playerId;
			Skills = skills;
		}

	}
}
