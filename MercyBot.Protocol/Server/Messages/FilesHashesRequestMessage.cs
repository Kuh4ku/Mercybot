using System.IO;

namespace MercyBot.Server.Messages
{
    public class FilesHashesRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 36;


        // Properties
        public short MessageId => ProtocolId;


        // Constructor
        public FilesHashesRequestMessage() { }


        public void Serialize(BinaryWriter writer)
        {
        }

        public void Deserialize(BinaryReader reader)
        {
        }

    }
}