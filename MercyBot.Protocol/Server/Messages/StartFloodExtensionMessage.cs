using System.IO;

namespace MercyBot.Server.Messages
{
    public class StartFloodExtensionMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 33;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }


        // Constructor
        public StartFloodExtensionMessage() { }

        public StartFloodExtensionMessage(string account)
        {
            Account = account;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Account);
        }

        public void Deserialize(BinaryReader reader)
        {
            Account = reader.ReadString();
        }

    }

}