using MercyBot.Server.Enums;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class ShowFunctionalityMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 19;


        // Properties
        public short MessageId => ProtocolId;
        public Functionalities Functionality { get; private set; }


        // Constructor
        public ShowFunctionalityMessage() { }

        public ShowFunctionalityMessage(Functionalities functionality)
        {
            Functionality = functionality;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)Functionality);
        }

        public void Deserialize(BinaryReader reader)
        {
            Functionality = (Functionalities)reader.ReadByte();
        }

    }

}