namespace MercyBot.Protocol.Messages
{
    public class ConnectionFailedMessage : Message
    {

        // Properties
        public string Reason { get; set; }


        // Constructor
        public ConnectionFailedMessage(string reason)
        {
            Reason = reason;
        }

    }
}
