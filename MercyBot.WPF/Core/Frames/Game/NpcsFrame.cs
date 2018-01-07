using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;

namespace MercyBot.Core.Frames.Game
{
    public static class NpcsFrame
    {

        public static Task HandleNpcDialogCreationMessage(Account account, NpcDialogCreationMessage message)
            => Task.Run(() => account.Game.Npcs.Update(message));

        public static Task HandleNpcDialogQuestionMessage(Account account, NpcDialogQuestionMessage message)
            => Task.Run(() => account.Game.Npcs.Update(message));

        public static Task HandleLeaveDialogMessage(Account account, LeaveDialogMessage message)
            => Task.Run(() => account.Game.Npcs.Update(message));

    }
}
