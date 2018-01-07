using MercyBot.Protocol.Messages;
using System.Linq;

namespace MercyBot.Core.Accounts.InGame.Map.Entities
{
    public class MovableEntity
    {
 
        // Properties
        public short CellId { get; protected set; }


        #region Updates

        public void Update(GameMapMovementMessage message)
        {
            CellId = (short)message.KeyMovements.Last();
        }

        #endregion

    }
}
