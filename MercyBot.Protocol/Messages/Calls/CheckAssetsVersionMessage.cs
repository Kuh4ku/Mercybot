namespace MercyBot.Protocol.Messages
{
    public class CheckAssetsVersionMessage : Message
    {

        // Properties
        public string AssetsVersion { get; set; }
        public string StaticDataVersion { get; set; }


        // Constructor
        public CheckAssetsVersionMessage(string assetsVersion, string staticDataVersion)
        {
            AssetsVersion = assetsVersion;
            StaticDataVersion = staticDataVersion;
        }

    }
}