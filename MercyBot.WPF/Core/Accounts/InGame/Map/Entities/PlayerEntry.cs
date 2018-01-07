using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Map.Entities
{
    public class PlayerEntry : MovableEntity
    {

        // Properties
        public int Id { get; private set; }
        public string Name { get; private set; }
        public byte Level { get; private set; }


        // Constructor
        public PlayerEntry(GameRolePlayCharacterInformations infos)
        {
            Id = infos.ContextualId;
            Name = infos.Name;
            CellId = (short)infos.Disposition.CellId;
            Level = (byte)(infos.AlignmentInfos.CharacterPower - Id);
        }

        public PlayerEntry(GameRolePlayMutantInformations mutantInfos)
        {
            Id = mutantInfos.ContextualId;
            Name = mutantInfos.Name;
            CellId = (short)mutantInfos.Disposition.CellId;
            Level = 0; // TODO get monster level maybe?
        }


        #region Updates

        public void Update(TeleportOnSameMapMessage message)
        {
            CellId = (short)message.CellId;
        }

        #endregion

    }
}
