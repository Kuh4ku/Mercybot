using System.IO;

namespace MercyBot.Server.Messages
{
    public class StartScriptRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 26;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }


        // Constructor
        public StartScriptRequestMessage() { }

        public StartScriptRequestMessage(string account)
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