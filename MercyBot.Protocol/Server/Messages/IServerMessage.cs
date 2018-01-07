using System.IO;

namespace MercyBot.Server.Messages
{
    public interface IServerMessage
    {

        short MessageId { get; }

        void Serialize(BinaryWriter writer);
        void Deserialize(BinaryReader reader);

    }
}
