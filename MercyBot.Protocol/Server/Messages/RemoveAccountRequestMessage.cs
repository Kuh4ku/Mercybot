using System.IO;

namespace MercyBot.Server.Messages
{
    public class RemoveAccountRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 9;


        // Properties
        public short MessageId => ProtocolId;
        public string Username { get; private set; }


        // Constructor
        public RemoveAccountRequestMessage() { }

        public RemoveAccountRequestMessage(string username)
        {
            Username = username;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Username);
        }

        public void Deserialize(BinaryReader reader)
        {
            Username = reader.ReadString();
        }

    }

}