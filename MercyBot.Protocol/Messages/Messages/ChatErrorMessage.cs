namespace MercyBot.Protocol.Messages
{
    public class ChatErrorMessage : Message
	{

		// Properties
		public string Reason { get; set; }


		// Constructors
		public ChatErrorMessage() { }

		public ChatErrorMessage(string reason = "")
		{
			Reason = reason;
		}

	}
}
