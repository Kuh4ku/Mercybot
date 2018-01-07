using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class Version
	{

		// Properties
		public uint Major { get; set; }
		public uint Minor { get; set; }
		public uint Release { get; set; }
		public uint Revision { get; set; }
		public uint Patch { get; set; }
		public uint BuildType { get; set; }


		// Constructors
		public Version() { }

		public Version(uint major = 0, uint minor = 0, uint release = 0, uint revision = 0, uint patch = 0, uint buildType = 0)
		{
			Major = major;
			Minor = minor;
			Release = release;
			Revision = revision;
			Patch = patch;
			BuildType = buildType;
		}

	}
}
