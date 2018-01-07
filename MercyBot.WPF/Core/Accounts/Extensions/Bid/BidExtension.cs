using GalaSoft.MvvmLight;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;
using ExtensionsEnum = MercyBot.Protocol.Server.Enums.Extensions;

namespace MercyBot.Core.Accounts.Extensions.Bid
{
    public class BidExtension : ViewModelBase, IDisposable
    {

        // Fields
        private Account _account;
        private Timer _timer;
        private uint _kamasGained;
        private uint _kamasPaidOnTaxes;
        private bool _enabled;
        private bool _waiting;
        private Dictionary<uint, uint[]> _pricesInBid;


        // Properties
        public BidConfiguration Configuration { get; private set; }
        public uint KamasGained
        {
            get => _kamasGained;
            set => Set(ref _kamasGained, value);
        }
        public uint KamasPaidOnTaxes
        {
            get => _kamasPaidOnTaxes;
            set => Set(ref _kamasPaidOnTaxes, value);
        }
        public bool Enabled
        {
            get => _enabled;
            set => Set(ref _enabled, value);
        }

        private bool Running => _enabled && !_waiting && MercyBotMain.Instance.Server.IsSubscribedToTouch && MercyBotMain.Instance.Server.HasExtension(ExtensionsEnum.HDV);


        // Events
        public event Action Started;
        public event Action Stopped;
        public event Action StatisticsUpdated;


        // Constructor
        public BidExtension(Account account)
        {
            _account = account;
            Configuration = new BidConfiguration(account);
            _timer = new Timer(Timer_Callback, null, -1, -1);

            _account.Game.Bid.StartedBuying += Bid_StartedBuying;
            _account.Game.Bid.StartedSelling += Bid_StartedSelling;
            _account.Scripts.ScriptStopped += Scripts_ScriptStopped;
            _account.Network.RegisterMessage<ExchangeBidHouseItemAddOkMessage>(HandleExchangeBidHouseItemAddOkMessage);
            _account.Network.RegisterMessage<TextInformationMessage>(HandleTextInformationMessage);
        }


        public void Start()
        {
            if (Enabled)
                return;

            if (Configuration.ObjectsToSell.Count == 0)
            {
                _account.Logger.LogError(LanguageManager.Translate("34"), LanguageManager.Translate("35"));
                return;
            }

            Enabled = true;
            _timer.Change(0, 0);

            Started?.Invoke();
        }

        public void Stop()
        {
            if (!Enabled)
                return;

            Enabled = false;
            _timer.Change(-1, -1);
            Stopped?.Invoke();
        }

        private void Process()
        {
            if (!Running)
                return;

            _account.Logger.LogDebug(LanguageManager.Translate("34"), LanguageManager.Translate("36"));
            _account.Game.Bid.StartBuying();
        }

        private void Bid_StartedBuying()
        {
            Task.Factory.StartNew(async () =>
            {
                if (!Running)
                    return;

                await Task.Delay(400);

                // Get all the prices and save them
                _pricesInBid = new Dictionary<uint, uint[]>();
                foreach (uint gid in Configuration.ObjectsToSell.Select(o => o.GID).Distinct())
                {
                    _pricesInBid.Add(gid, _account.Game.Bid.GetItemPrices(gid));
                    await Task.Delay(800);
                }

                // Close the bidbuyer
                _account.Logger.LogInfo(LanguageManager.Translate("34"), LanguageManager.Translate("37"));
                _account.LeaveDialog();
                await Task.Delay(600);

                // Open bidseller
                _account.Game.Bid.StartSelling();

            }, TaskCreationOptions.LongRunning);
        }

        private void Timer_Callback(object state)
        {
            _waiting = false;
            _timer.Change(-1, -1);

            if (!Enabled)
                return;

            Process();
        }

        private void Scripts_ScriptStopped(string scriptTitle)
        {
            if (!Enabled)
                return;

            SetTimerInterval();
        }

        private async void Bid_StartedSelling()
        {
            // Process sales session
            await ProcessSalesSession();
        }

        private async Task ProcessSalesSession()
        {
            if (!Running)
                return;

            _account.Logger.LogInfo(LanguageManager.Translate("34"), LanguageManager.Translate("38"));

            // For every ObjectToSell that we have
            for (int i = 0; i < Configuration.ObjectsToSell.Count; i++)
            {
                var objToSell = Configuration.ObjectsToSell[i];

                // Get the items that are already in the bid for this specific ObjectToSell
                var objsInSale = _account.Game.Bid.ObjectsInSale.Where(o => o.ObjectGID == objToSell.GID && o.Quantity == objToSell.Lot).ToList();

                // Get the price in bid of this specific ObjectToSell
                uint priceInBid = _pricesInBid[objToSell.GID][LotToIndex(objToSell.Lot)];
                // This will hold the price that should our objects have (either modified or added)
                uint newPrice = priceInBid;
                bool ours = true;

                // If the price in bid is 0 (sold out), the new price will be the base price
                if (priceInBid == 0)
                {
                    newPrice = objToSell.BasePrice;
                }
                // If we have no objects in sale, the new price will be the price in bid - 1
                else if (objsInSale.Count == 0)
                {
                    newPrice = priceInBid - 1;
                }
                // If the price in bid is not 0 and we have objects in sale
                else
                {
                    // Get the smallest price in our objects in sale
                    uint smallestPrice = objsInSale.Min(o => o.ObjectPrice);

                    // If the price in the bid is less than the smallest price in our objects in sale, it means it's not ours
                    if (priceInBid < smallestPrice)
                    {
                        ours = false;
                        newPrice = priceInBid - 1;
                    }
                }

                // If the price is invalid, ignore this object to sell
                if (IsPriceInvalid(objToSell, priceInBid, newPrice))
                    continue;

                // Check if we need to modify our objects in sale
                if (!ours && objsInSale.Count > 0)
                {
                    for (int j = 0; j < objsInSale.Count; j++)
                    {
                        _account.Logger.LogDebug(LanguageManager.Translate("34"), LanguageManager.Translate("39", objToSell.Lot, objToSell.Name, newPrice));
                        if (_account.Game.Bid.EditItemInSalePrice(objsInSale[j].ObjectUID, newPrice))
                        {
                            await Task.Delay(800);
                        }
                    }
                }

                // Check if we need to sell more objects
                if (objToSell.Quantity - objsInSale.Count > 0)
                {
                    // Sell as long as we have the enough in the inventory
                    uint qty = _account.Game.Character.Inventory.GetObjectByGID((int)objToSell.GID)?.Quantity ?? 0;

                    for (int j = 0; j < (objToSell.Quantity - objsInSale.Count); j++)
                    {
                        // Check if we don't have the needed quantity in our inventory
                        if (qty < objToSell.Lot)
                        {
                            _account.Logger.LogWarning(LanguageManager.Translate("34"), LanguageManager.Translate("40", objToSell.Lot, objToSell.Name));
                            break;
                        }

                        // If we do, try and sell!
                        _account.Logger.LogDebug(LanguageManager.Translate("34"), LanguageManager.Translate("41", objToSell.Lot, objToSell.Name, newPrice));
                        if (_account.Game.Bid.SellItem(objToSell.GID, objToSell.Lot, newPrice))
                        {
                            qty -= objToSell.Lot;
                            await Task.Delay(800);
                        }
                    }
                }
            }

            _account.Logger.LogInfo(LanguageManager.Translate("34"), LanguageManager.Translate("42"));
            _account.LeaveDialog();
            await Task.Delay(800);

            // Check if we need to start a script
            if (Configuration.IsScriptPathValid)
            {
                try
                {
                    _account.Scripts.FromFile(Configuration.ScriptPath);
                    // We'll just assume that if we got to this line, the script will 100% start
                    _account.Scripts.StartScript();
                }
                catch (Exception ex)
                {
                    _account.Logger.LogError(LanguageManager.Translate("43"), ex.Message);
                }
            }
            // Or just start waiting
            else
            {
                SetTimerInterval();
            }
        }

        private Task HandleExchangeBidHouseItemAddOkMessage(Account account, ExchangeBidHouseItemAddOkMessage message)
            => Task.Run(() =>
            {
                KamasPaidOnTaxes += (uint)Math.Max(1, Math.Round((double)message.ItemInfo.ObjectPrice * 3 / 100));
                StatisticsUpdated?.Invoke();
            });

        private Task HandleTextInformationMessage(Account account, TextInformationMessage message)
            => Task.Run(() =>
            {
                if (message.MsgId == 65 && message.Parameters.Count > 0)
                {
                    KamasGained += Convert.ToUInt32(message.Parameters[0]);
                    StatisticsUpdated?.Invoke();
                }
            });

        private void SetTimerInterval()
        {
            _waiting = true;
            _account.Logger.LogInfo(LanguageManager.Translate("34"), LanguageManager.Translate("44", Configuration.Interval));
            _timer.Change(Configuration.Interval * 60000, Configuration.Interval * 60000);
        }

        private bool IsPriceInvalid(ObjectToSellEntry objToSell, uint priceInBid, uint newPrice)
        {
            if (newPrice == 0)
            {
                _account.Logger.LogWarning(LanguageManager.Translate("34"), LanguageManager.Translate("45", objToSell.Lot, objToSell.Name));
                return true;
            }

            if (newPrice < objToSell.MinPrice)
            {
                _account.Logger.LogWarning(LanguageManager.Translate("34"), LanguageManager.Translate("46", objToSell.Lot, objToSell.Name, priceInBid, objToSell.MinPrice));
                return true;
            }

            return false;
        }

        private int LotToIndex(uint lot)
            => lot == 1 ? 0 : lot == 10 ? 1 : 2;

        public void Clear()
        {
            KamasGained = 0;
            KamasPaidOnTaxes = 0;
            _pricesInBid = null;
            _waiting = false;
            Stop();
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Configuration.Dispose();
                    _timer.Change(-1, -1);
                    _timer.Dispose();
                }

                Configuration = null;
                Enabled = false;
                _waiting = false;
                _timer = null;
                _account = null;

                disposedValue = true;
            }
        }

        ~BidExtension() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
