using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterExperienceGainMessage : Message
	{

		// Properties
		public double ExperienceCharacter { get; set; }
		public double ExperienceMount { get; set; }
		public double ExperienceGuild { get; set; }
		public double ExperienceIncarnation { get; set; }


		// Constructors
		public CharacterExperienceGainMessage() { }

		public CharacterExperienceGainMessage(double experienceCharacter = 0, double experienceMount = 0, double experienceGuild = 0, double experienceIncarnation = 0)
		{
			ExperienceCharacter = experienceCharacter;
			ExperienceMount = experienceMount;
			ExperienceGuild = experienceGuild;
			ExperienceIncarnation = experienceIncarnation;
		}

	}
}
