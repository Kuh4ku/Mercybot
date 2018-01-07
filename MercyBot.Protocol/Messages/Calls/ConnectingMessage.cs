namespace MercyBot.Protocol.Messages
{
    public class ConnectingMessage : Message
    {

        // Properties
        public string AppVersion { get; set; }
        public string BuildVersion { get; set; }
        public string Language { get; set; }
        public string Server { get; set; }
        public string Client { get; set; }


        // Constructor
        public ConnectingMessage(string appVersion, string buildVersion, string language, string server, string client)
        {
            AppVersion = appVersion;
            BuildVersion = buildVersion;
            Language = language;
            Server = server;
            Client = client;
        }

    }
}