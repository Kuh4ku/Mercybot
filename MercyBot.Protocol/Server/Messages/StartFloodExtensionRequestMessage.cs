using System.IO;

namespace MercyBot.Server.Messages
{
    public class StartFloodExtensionRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 32;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }


        // Constructor
        public StartFloodExtensionRequestMessage() { }

        public StartFloodExtensionRequestMessage(string account)
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