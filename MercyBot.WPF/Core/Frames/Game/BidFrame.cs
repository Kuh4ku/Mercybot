using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;

namespace MercyBot.Core.Frames.Game
{
    public static class BidFrame
    {

        public static Task HandleExchangeStartedBidBuyerMessage(Account account, ExchangeStartedBidBuyerMessage message)
           => Task.Run(() => account.Game.Bid.Update(message));

        public static Task HandleExchangeTypesItemsExchangerDescriptionForUserMessage(Account account, ExchangeTypesItemsExchangerDescriptionForUserMessage message)
            => Task.Run(() => account.Game.Bid.Update(message));

        public static Task HandleExchangeStartedBidSellerMessage(Account account, ExchangeStartedBidSellerMessage message)
            => Task.Run(() => account.Game.Bid.Update(message));

        public static Task HandleExchangeErrorMessage(Account account, ExchangeErrorMessage message)
            => Task.Run(() => account.Game.Bid.Update(message));

        public static Task HandleExchangeLeaveMessage(Account account, ExchangeLeaveMessage message)
            => Task.Run(() => account.Game.Bid.Update(message));

    }
}
