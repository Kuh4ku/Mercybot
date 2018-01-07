using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;

namespace MercyBot.Core.Frames.Game
{
    public static class ExchangeFrame
    {

        public static Task HandleExchangeRequestedTradeMessage(Account account, ExchangeRequestedTradeMessage message)
            => Task.Run(async () =>
            {
                await Task.Delay(200);
                account.Game.Exchange.Update(message);
            });

        public static Task HandleExchangeStartedWithPodsMessage(Account account, ExchangeStartedWithPodsMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

        public static Task HandleExchangeObjectAddedMessage(Account account, ExchangeObjectAddedMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

        public static Task HandleExchangeObjectModifiedMessage(Account account, ExchangeObjectModifiedMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

        public static Task HandleExchangeObjectRemovedMessage(Account account, ExchangeObjectRemovedMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

        public static Task HandleExchangeKamaModifiedMessage(Account account, ExchangeKamaModifiedMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

        public static Task HandleExchangeIsReadyMessage(Account account, ExchangeIsReadyMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

        public static Task HandleExchangeLeaveMessage(Account account, ExchangeLeaveMessage message)
            => Task.Run(() => account.Game.Exchange.Update(message));

    }
}
