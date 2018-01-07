using System.IO;

namespace MercyBot.Server.Messages
{
    public class ConnectAccountMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 12;


        // Properties
        public short MessageId => ProtocolId;
        public string Username { get; private set; }


        // Constructor
        public ConnectAccountMessage() { }

        public ConnectAccountMessage(string username)
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