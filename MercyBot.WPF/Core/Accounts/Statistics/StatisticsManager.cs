using GalaSoft.MvvmLight;
using MercyBot.Core.Accounts.InGame.Managers.Gathers;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace MercyBot.Core.Accounts.Statistics
{
    public class StatisticsManager : ViewModelBase, IDisposable
    {

        // Fields
        private Account _account;
        //-> General
        private uint _levelsGained;
        private uint _experienceGained;
        private uint _kamasGained;
        private uint _achievementsFinished;
        //-> Fights
        private TimeSpan _totalFightsTime;
        private TimeSpan _averageFightTime;
        private uint _fightsCount;
        private uint _fightsWon;
        private uint _fightsLost;
        //-> Gathers
        private TimeSpan _totalGathersTime;
        private uint _gathersCount;
        private Stopwatch _gatherTime;
        private uint _lastObjectGained;


        // Properties
        //-> General
        public uint LevelsGained
        {
            get => _levelsGained;
            set => Set(ref _levelsGained, value);
        }
        public uint ExperienceGained
        {
            get => _experienceGained;
            set => Set(ref _experienceGained, value);
        }
        public uint KamasGained
        {
            get => _kamasGained;
            set => Set(ref _kamasGained, value);
        }
        public uint AchievementsFinished
        {
            get => _achievementsFinished;
            set => Set(ref _achievementsFinished, value);
        }
        //-> Fights
        public uint FightsCount
        {
            get => _fightsCount;
            set => Set(ref _fightsCount, value);
        }
        public TimeSpan TotalFightsTime
        {
            get => _totalFightsTime;
            set => Set(ref _totalFightsTime, value);
        }
        public TimeSpan AverageFightTime
        {
            get => _averageFightTime;
            set => Set(ref _averageFightTime, value);
        }
        public uint FightsWon
        {
            get => _fightsWon;
            set => Set(ref _fightsWon, value);
        }
        public uint FightsLost
        {
            get => _fightsLost;
            set => Set(ref _fightsLost, value);
        }
        public ObservableCollection<ObjectObtainedEntry> ObjectsObtainedInFights { get; private set; }
        //-> Gathers
        public uint GathersCount
        {
            get => _gathersCount;
            set => Set(ref _gathersCount, value);
        }
        public TimeSpan TotalGathersTime
        {
            get => _totalGathersTime;
            set => Set(ref _totalGathersTime, value);
        }
        public ObservableCollection<ObjectObtainedEntry> ObjectsObtainedInGathers { get; private set; }


        // Constructor
        public StatisticsManager(Account account)
        {
            _account = account;

            // I don't know if a TimeSpan has a default value, but just in case
            TotalFightsTime = TimeSpan.Zero;
            TotalGathersTime = TimeSpan.Zero;
            ObjectsObtainedInFights = new ObservableCollection<ObjectObtainedEntry>();
            ObjectsObtainedInGathers = new ObservableCollection<ObjectObtainedEntry>();

            _account.Game.Managers.Gathers.GatherStarted += Gathers_GatherStarted;
            _account.Game.Managers.Gathers.GatherFinished += Gathers_GatherFinished;
            _account.Game.Character.Inventory.ObjectGained += Inventory_ObjectGained;
        }


        private void Gathers_GatherStarted()
        {
            _gatherTime = Stopwatch.StartNew();
        }

        private void Gathers_GatherFinished(GatherResults result)
        {
            if (result == GatherResults.GATHERED)
            {
                GathersCount++;
                TotalGathersTime = TotalGathersTime.Add(TimeSpan.FromMilliseconds(_gatherTime.Elapsed.TotalMilliseconds));
            }
        }

        private void Inventory_ObjectGained(uint gid)
        {
            _lastObjectGained = gid;
        }

        #region Updates

        public void Update(GameFightEndMessage message)
        {
            TotalFightsTime = TotalFightsTime.Add(TimeSpan.FromMilliseconds(message.Duration));
            AverageFightTime = TimeSpan.FromMilliseconds((AverageFightTime.TotalMilliseconds + message.Duration) / 2);
            FightsCount++;

            for (int i = 0; i < message.Results.Count; i++)
            {
                // Check for our player's result
                if (message.Results[i] is FightResultPlayerListEntry result && result.Id == _account.Game.Character.Id)
                {
                    KamasGained += result.Rewards.Kamas;

                    // Outcome 0 = LOST
                    if (result.Outcome == 0)
                    {
                        FightsLost++;
                    }
                    else
                    {
                        FightsWon++;
                    }

                    // Objects obtained
                    for (int j = 0; j < result.Rewards.Objects.Count; j += 2)
                    {
                        AddOrUpdate(ObjectsObtainedInFights, result.Rewards.Objects[j], result.Rewards.Objects[j + 1]);
                    }
                }
            }

            // Set objects' percentages
            uint totalQty = (uint)ObjectsObtainedInFights.Sum(o => o.Quantity);
            for (int i = 0; i < ObjectsObtainedInFights.Count; i++)
            {
                ObjectsObtainedInFights[i].Percentage = (uint)((double)ObjectsObtainedInFights[i].Quantity / totalQty * 100);
            }
        }

        public void Update(CharacterExperienceGainMessage message)
        {
            ExperienceGained += (uint)message.ExperienceCharacter;
        }

        public void Update(CharacterLevelUpMessage message)
        {
            LevelsGained += (message.NewLevel - _account.Game.Character.Level);
        }

        public void Update(AchievementRewardSuccessMessage message)
        {
            AchievementsFinished++;
        }

        public void Update(DisplayNumericalValueMessage message)
        {
            if (message.EntityId == _account.Game.Character.Id && _lastObjectGained != 0)
            {
                AddOrUpdate(ObjectsObtainedInGathers, _lastObjectGained, (uint)message.Value);
                _lastObjectGained = 0;

                // Set objects' percentages
                uint totalQty = (uint)ObjectsObtainedInGathers.Sum(o => o.Quantity);
                for (int i = 0; i < ObjectsObtainedInGathers.Count; i++)
                {
                    ObjectsObtainedInGathers[i].Percentage = (uint)((double)ObjectsObtainedInGathers[i].Quantity / totalQty * 100);
                }
            }
        }

        #endregion

        private void AddOrUpdate(ObservableCollection<ObjectObtainedEntry> list, uint gid, uint qty)
        {
            var elem = list.FirstOrDefault(o => o.GID == gid);

            if (elem == null)
            {
                elem = new ObjectObtainedEntry(gid, DataManager.Get<Items>((int)gid).NameId, 0);
                Application.Current.Dispatcher.Invoke(() => list.Add(elem));
            }

            elem.Quantity += qty;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _account = null;

                disposedValue = true;
            }
        }

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
