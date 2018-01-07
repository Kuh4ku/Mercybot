using System.IO;

namespace MercyBot.Server.Messages
{
    public class PingMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 37;


        // Properties
        public short MessageId => ProtocolId;


        // Constructor
        public PingMessage() { }


        public void Serialize(BinaryWriter writer)
        {
        }

        public void Deserialize(BinaryReader reader)
        {
        }

    }
}