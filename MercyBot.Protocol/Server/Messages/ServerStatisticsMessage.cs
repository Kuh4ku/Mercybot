using System.IO;

namespace MercyBot.Server.Messages
{
    public class ServerStatisticsMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 6;


        // Properties
        public short MessageId => ProtocolId;
        public int AccountsCount { get; private set; }
        public int BotsCount { get; private set; }


        // Constructor
        public ServerStatisticsMessage() { }

        public ServerStatisticsMessage(int accountsCount, int botsCount)
        {
            AccountsCount = accountsCount;
            BotsCount = botsCount;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(AccountsCount);
            writer.Write(BotsCount);
        }

        public void Deserialize(BinaryReader reader)
        {
            AccountsCount = reader.ReadInt32();
            BotsCount = reader.ReadInt32();
        }

    }

}