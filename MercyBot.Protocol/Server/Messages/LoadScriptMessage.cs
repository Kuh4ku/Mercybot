using System.IO;

namespace MercyBot.Server.Messages
{
    public class LoadScriptMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 25;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }
        public string Path { get; private set; }


        // Constructor
        public LoadScriptMessage() { }

        public LoadScriptMessage(string account, string path)
        {
            Account = account;
            Path = path;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Account);
            writer.Write(Path);
        }

        public void Deserialize(BinaryReader reader)
        {
            Account = reader.ReadString();
            Path = reader.ReadString();
        }

    }

}