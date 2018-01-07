using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PartyGuestInformations
	{

		// Properties
		public List<PartyCompanionBaseInformations> Companions { get; set; }
		public uint GuestId { get; set; }
		public uint HostId { get; set; }
		public string Name { get; set; }
		public EntityLook GuestLook { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public PlayerStatus Status { get; set; }


		// Constructors
		public PartyGuestInformations() { }

		public PartyGuestInformations(uint guestId = 0, uint hostId = 0, string name = "", EntityLook guestLook = null, int breed = 0, bool sex = false, PlayerStatus status = null, List<PartyCompanionBaseInformations> companions = null)
		{
			GuestId = guestId;
			HostId = hostId;
			Name = name;
			GuestLook = guestLook;
			Breed = breed;
			Sex = sex;
			Status = status;
			Companions = companions;
		}

	}
}
