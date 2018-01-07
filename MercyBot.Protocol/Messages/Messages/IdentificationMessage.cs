using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IdentificationMessage : Message
	{

		// Properties
		public List<int> Credentials { get; set; }
		public string Lang { get; set; }
		public int ServerId { get; set; }
		public bool Autoconnect { get; set; }
		public bool UseCertificate { get; set; }
		public bool UseLoginToken { get; set; }
		public double SessionOptionalSalt { get; set; }


		// Constructors
		public IdentificationMessage() { }

		public IdentificationMessage(string lang = "", int serverId = 0, bool autoconnect = false, bool useCertificate = false, bool useLoginToken = false, double sessionOptionalSalt = 0, List<int> credentials = null)
		{
			Lang = lang;
			ServerId = serverId;
			Autoconnect = autoconnect;
			UseCertificate = useCertificate;
			UseLoginToken = useLoginToken;
			SessionOptionalSalt = sessionOptionalSalt;
			Credentials = credentials;
		}

	}
}
