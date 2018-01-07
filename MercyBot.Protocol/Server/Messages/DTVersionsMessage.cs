using System.IO;

namespace MercyBot.Server.Messages
{
    public class DTVersionsMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 34;


        // Properties
        public short MessageId => ProtocolId;
        public string AppVersion { get; private set; }
        public string BuildVersion { get; private set; }
        public string AssetsVersion { get; private set; }
        public string StaticDataVersion { get; private set; }


        // Constructor
        public DTVersionsMessage() { }

        public DTVersionsMessage(string appVersion, string buildVersion, string assetsVersion, string staticDataVersion)
        {
            AppVersion = appVersion;
            BuildVersion = buildVersion;
            AssetsVersion = assetsVersion;
            StaticDataVersion = staticDataVersion;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(AppVersion);
            writer.Write(BuildVersion);
            writer.Write(AssetsVersion);
            writer.Write(StaticDataVersion);
        }

        public void Deserialize(BinaryReader reader)
        {
            AppVersion = reader.ReadString();
            BuildVersion = reader.ReadString();
            AssetsVersion = reader.ReadString();
            StaticDataVersion = reader.ReadString();
        }

    }

}