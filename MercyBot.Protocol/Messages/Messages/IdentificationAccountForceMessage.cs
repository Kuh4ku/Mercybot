using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IdentificationAccountForceMessage : IdentificationMessage
	{

		// Properties
		public string ForcedAccountLogin { get; set; }


		// Constructors
		public IdentificationAccountForceMessage() { }

		public IdentificationAccountForceMessage(string lang = "", int serverId = 0, bool autoconnect = false, bool useCertificate = false, bool useLoginToken = false, double sessionOptionalSalt = 0, string forcedAccountLogin = "", List<int> credentials = null)
		{
			Lang = lang;
			ServerId = serverId;
			Autoconnect = autoconnect;
			UseCertificate = useCertificate;
			UseLoginToken = useLoginToken;
			SessionOptionalSalt = sessionOptionalSalt;
			ForcedAccountLogin = forcedAccountLogin;
			Credentials = credentials;
		}

	}
}
