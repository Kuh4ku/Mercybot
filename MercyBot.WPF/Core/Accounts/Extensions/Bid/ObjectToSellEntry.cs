using System.IO;

namespace MercyBot.Core.Accounts.Extensions.Bid
{
    public class ObjectToSellEntry
    {

        // Properties
        public string Name { get; private set; }
        public uint GID { get; private set; }
        public uint Lot { get; private set; }
        public uint Quantity { get; private set; }
        public uint MinPrice { get; private set; }
        public uint BasePrice { get; private set; }


        // Constructor
        public ObjectToSellEntry(string name, uint gid, uint lot, uint qty, uint minPrice, uint basePrice)
        {
            Name = name;
            GID = gid;
            Lot = lot;
            Quantity = qty;
            MinPrice = minPrice;
            BasePrice = basePrice;
        }


        public void Save(BinaryWriter bw)
        {
            bw.Write(Name);
            bw.Write(GID);
            bw.Write(Lot);
            bw.Write(Quantity);
            bw.Write(MinPrice);
            bw.Write(BasePrice);
        }

        public static ObjectToSellEntry Load(BinaryReader br)
            => new ObjectToSellEntry(br.ReadString(), br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());

    }
}
