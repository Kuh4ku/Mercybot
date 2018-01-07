using System.Collections.Generic;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class BotsInformationsRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 16;


        // Properties
        public short MessageId => ProtocolId;


        // Constructor
        public BotsInformationsRequestMessage() { }


        public void Serialize(BinaryWriter writer)
        {
            
        }

        public void Deserialize(BinaryReader reader)
        {
            
        }

    }

}