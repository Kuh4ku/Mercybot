namespace MercyBot.Protocol.Messages.Messages
{
    public class GameRolePlayAttackMonsterRequestMessage : Message
    {

        // Properties
        public int MonsterGroupId { get; }


        // Constructor
        public GameRolePlayAttackMonsterRequestMessage() { }

        public GameRolePlayAttackMonsterRequestMessage(int monsterGroupId)
        {
            MonsterGroupId = monsterGroupId;
        }


    }
}
