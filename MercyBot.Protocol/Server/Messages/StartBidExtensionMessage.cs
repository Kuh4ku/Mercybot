using System.IO;

namespace MercyBot.Server.Messages
{
    public class StartBidExtensionMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 31;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }


        // Constructor
        public StartBidExtensionMessage() { }

        public StartBidExtensionMessage(string account)
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