using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class VersionExtended : Version
	{

		// Properties
		public uint Install { get; set; }
		public uint Technology { get; set; }


		// Constructors
		public VersionExtended() { }

		public VersionExtended(uint major = 0, uint minor = 0, uint release = 0, uint revision = 0, uint patch = 0, uint buildType = 0, uint install = 0, uint technology = 0)
		{
			Major = major;
			Minor = minor;
			Release = release;
			Revision = revision;
			Patch = patch;
			BuildType = buildType;
			Install = install;
			Technology = technology;
		}

	}
}
