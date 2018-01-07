using MercyBot.Server.Enums;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class InvalidOperationMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 11;


        // Properties
        public short MessageId => ProtocolId;
        public InvalidOperations Operation { get; private set; }


        // Constructor
        public InvalidOperationMessage() { }

        public InvalidOperationMessage(InvalidOperations operation)
        {
            Operation = operation;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)Operation);
        }

        public void Deserialize(BinaryReader reader)
        {
            Operation = (InvalidOperations)reader.ReadByte();
        }

    }

}