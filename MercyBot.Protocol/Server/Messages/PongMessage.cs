using System.IO;

namespace MercyBot.Server.Messages
{
    public class PongMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 38;


        // Properties
        public short MessageId => ProtocolId;


        // Constructor
        public PongMessage() { }


        public void Serialize(BinaryWriter writer)
        {
        }

        public void Deserialize(BinaryReader reader)
        {
        }

    }
}