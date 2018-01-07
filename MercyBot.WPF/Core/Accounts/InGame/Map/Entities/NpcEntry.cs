using MercyBot.Protocol.Data;
using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Map.Entities
{
    public class NpcEntry
    {

        // Properties
        public int Id { get; private set; }
        public uint NpcId { get; private set; }
        public short CellId { get; private set; }
        public Protocol.Data.Npcs Data { get; private set; }

        public string Name => Data.NameId;


        // Constructor
        public NpcEntry(GameRolePlayNpcInformations infos)
        {
            Id = infos.ContextualId;
            NpcId = infos.NpcId;
            CellId = (short)infos.Disposition.CellId;
            Data = DataManager.Get<Protocol.Data.Npcs>((int)NpcId);
        }

    }
}
