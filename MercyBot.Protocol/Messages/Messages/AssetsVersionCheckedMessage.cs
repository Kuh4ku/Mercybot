namespace MercyBot.Protocol.Messages
{
    public class AssetsVersionCheckedMessage : Message
    {

        // Properties
        public string AssetsVersion { get; set; }
        public string StaticDataVersion { get; set; }

    }
}