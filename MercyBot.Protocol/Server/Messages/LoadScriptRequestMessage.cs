using System.IO;

namespace MercyBot.Server.Messages
{
    public class LoadScriptRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 24;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set;}
        public string Path { get; private set; }
        public string Content { get; private set; }


        // Constructor
        public LoadScriptRequestMessage() { }

        public LoadScriptRequestMessage(string account, string path, string content)
        {
            Account = account;
            Path = path;
            Content = content;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Account);
            writer.Write(Path);
            writer.Write(Content);
        }

        public void Deserialize(BinaryReader reader)
        {
            Account = reader.ReadString();
            Path = reader.ReadString();
            Content = reader.ReadString();
        }

    }
}