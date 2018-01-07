using System.Collections.Generic;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class BotsInformationsMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 17;


        // Properties
        public short MessageId => ProtocolId;
        public Dictionary<string, Bot> Bots { get; private set; }


        // Constructor
        public BotsInformationsMessage()
        {
            Bots = new Dictionary<string, Bot>();
        }

        public BotsInformationsMessage(Dictionary<string, Bot> bots)
        {
            Bots = bots;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Bots.Count);
            foreach (var kvp in Bots)
            {
                writer.Write(kvp.Key);
                kvp.Value.Serialize(writer);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Bots.Add(reader.ReadString(), Bot.Deserialize(reader));
            }
        }

    }

    public class Bot
    {

        // Properties
        public byte Level { get; private set; }
        public byte EnergyPercent { get; private set; }
        public byte WeightPercent { get; private set; }
        public int Kamas { get; private set; }
        public int MapId { get; private set; }
        public string MapPosition { get; private set; }
        public string State { get; private set; }


        // Constructor
        public Bot(byte level, byte energyPercent, byte weightPercent, int kamas, int mapId, string mapPosition, string state)
        {
            Level = level;
            EnergyPercent = energyPercent;
            WeightPercent = weightPercent;
            Kamas = kamas;
            MapId = mapId;
            MapPosition = mapPosition;
            State = state;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Level);
            writer.Write(EnergyPercent);
            writer.Write(WeightPercent);
            writer.Write(Kamas);
            writer.Write(MapId);
            writer.Write(MapPosition);
            writer.Write(State);
        }

        public static Bot Deserialize(BinaryReader reader)
            => new Bot(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadString(), reader.ReadString());

    }

}