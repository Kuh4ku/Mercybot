using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountInformationRequestMessage : Message
	{

		// Properties
		public double Id { get; set; }
		public double Time { get; set; }


		// Constructors
		public MountInformationRequestMessage() { }

		public MountInformationRequestMessage(double id = 0, double time = 0)
		{
			Id = id;
			Time = time;
		}

	}
}
