using System.IO;

namespace MercyBot.Server.Messages
{
    public class StartScriptMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 27;


        // Properties
        public short MessageId => ProtocolId;
        public string Account { get; private set; }


        // Constructor
        public StartScriptMessage() { }

        public StartScriptMessage(string account)
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