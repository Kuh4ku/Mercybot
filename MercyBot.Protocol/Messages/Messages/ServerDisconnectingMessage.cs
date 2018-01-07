namespace MercyBot.Protocol.Messages.Messages
{
    public class ServerDisconnectingMessage : Message
    {

        // Properties
        public string Reason { get; }


        // Constructor
        public ServerDisconnectingMessage(string reason)
        {
            Reason = reason;
        }

    }
}
