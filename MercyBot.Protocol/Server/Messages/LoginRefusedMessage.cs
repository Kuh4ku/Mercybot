using System.IO;

namespace MercyBot.Server.Messages
{
    public class LoginRefusedMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 3;


        // Properties
        public short MessageId => ProtocolId;
        public byte Reason { get; private set; }


        // Constructor
        public LoginRefusedMessage() { }

        public LoginRefusedMessage(byte reason)
        {
            Reason = reason;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Reason);
        }

        public void Deserialize(BinaryReader reader)
        {
            Reason = reader.ReadByte();
        }

    }

}