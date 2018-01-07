using System.IO;

namespace MercyBot.Server.Messages
{
    public class StartBidExtensionRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 30;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }


        // Constructor
        public StartBidExtensionRequestMessage() { }

        public StartBidExtensionRequestMessage(string account)
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