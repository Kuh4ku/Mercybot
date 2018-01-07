using MercyBot.Core.Accounts.InGame.Map.Entities;
using MercyBot.Core.Accounts.InGame.Map.Interactives;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Data.Maps;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MercyBot.Core.Enums;

namespace MercyBot.Core.Accounts.InGame.Map
{
    public class MapGame : ViewModelBase, IClearable, IDisposable
    {
        // Fields
        private static readonly List<int> DoorsSkillIds = new List<int>(new[] {184, 183, 187, 198, 114, 84});

        private static readonly List<int> DoorsTypeIds = new List<int>(new[] {-1, 128, 168, 16});
        private Account _account;
        private ConcurrentDictionary<int, PlayerEntry> _players;
        private ConcurrentDictionary<int, NpcEntry> _npcs;
        private ConcurrentDictionary<int, MonstersGroupEntry> _monstersGroups;
        private ConcurrentDictionary<int, InteractiveElementEntry> _interactives;
        private ConcurrentDictionary<int, ElementInCellEntry> _doors;
        private ConcurrentDictionary<int, StatedElementEntry> _statedElements;
        private ConcurrentDictionary<int, ElementInCellEntry> _phenixs;
        private ConcurrentDictionary<int, ElementInCellEntry> _lockedStorages;
        private string _area;
        private string _subArea;
        private bool _joinedFight;
        private bool _firstTime = true;


        // Properties
        public Protocol.Data.Maps.Map Data { get; private set; }

        public string Area
        {
            get => _area;
            set => Set(ref _area, value);
        }

        public string SubArea
        {
            get => _subArea;
            set => Set(ref _subArea, value);
        }

        public sbyte PosX { get; private set; }
        public sbyte PosY { get; private set; }
        public PlayerEntry PlayedCharacter { get; private set; }
        public List<short> TeleportableCells { get; private set; }
        public List<int> BlacklistedMonsters { get; private set; }
        public ElementInCellEntry Zaap { get; private set; }
        public ElementInCellEntry Zaapi { get; private set; }

        public IEnumerable<PlayerEntry> Players => _players.Values;
        public IEnumerable<NpcEntry> Npcs => _npcs.Values;
        public IEnumerable<MonstersGroupEntry> MonstersGroups => _monstersGroups.Values;
        public IEnumerable<InteractiveElementEntry> Interactives => _interactives.Values;
        public IEnumerable<ElementInCellEntry> Doors => _doors.Values;
        public IEnumerable<StatedElementEntry> StatedElements => _statedElements.Values;
        public IEnumerable<ElementInCellEntry> Phenixs => _phenixs.Values;
        public IEnumerable<ElementInCellEntry> LockedStroages => _lockedStorages.Values;
        public int Id => Data.Id;

        public List<short> OccupiedCells => Players.Select(f => f.CellId)
            .Union(MonstersGroups.Select(f => f.CellId))
            .Union(Npcs.Select(f => f.CellId)).ToList();

        public string CurrentPosition => $"{PosX},{PosY}";


        // Events
        public event Action MapChanged;
        public event Action MapLoaded;
        public event Action<PlayerEntry> PlayerJoined;
        public event Action<PlayerEntry> PlayerLeft;
        public event Action EntitiesUpdated;
        public event Action InteractivesUpdated;
        public event Action<List<short>> PlayedCharacterMoving;


        internal MapGame(Account account)
        {
            _account = account;
            TeleportableCells = new List<short>();
            _players = new ConcurrentDictionary<int, PlayerEntry>();
            _npcs = new ConcurrentDictionary<int, NpcEntry>();
            _monstersGroups = new ConcurrentDictionary<int, MonstersGroupEntry>();
            _interactives = new ConcurrentDictionary<int, InteractiveElementEntry>();
            _doors = new ConcurrentDictionary<int, ElementInCellEntry>();
            _statedElements = new ConcurrentDictionary<int, StatedElementEntry>();
            _phenixs = new ConcurrentDictionary<int, ElementInCellEntry>();
            _lockedStorages = new ConcurrentDictionary<int, ElementInCellEntry>();
            BlacklistedMonsters = new List<int>();
        }


        public async Task<bool> WaitMapChange(int maxDelayInSeconds)
        {
            bool mapChanged = false;

            void AccountMapChanged()
            {
                mapChanged = true;
            }

            _account.Game.Map.MapChanged += AccountMapChanged;

            for (int i = 0; i < maxDelayInSeconds && !mapChanged && _account.State != AccountStates.FIGHTING && _account.Scripts.Running; i++)
            {
                await Task.Delay(1000);
            }

            _account.Game.Map.MapChanged -= AccountMapChanged;

            return mapChanged;
        }

        public bool IsCellTeleportable(short cellId) => TeleportableCells.Contains(cellId);

        public StatedElementEntry GetStatedElement(int elementId)
        {
            if (_statedElements.TryGetValue(elementId, out StatedElementEntry element))
                return element;

            return null;
        }

        public InteractiveElementEntry GetInteractiveElement(int elementId)
        {
            if (_interactives.TryGetValue(elementId, out InteractiveElementEntry element))
                return element;

            return null;
        }

        public bool CanFight(int minMonsters, int maxMonsters, int minLevel, int maxLevel, List<int> forbiddenMonsters, List<int> mandatoryMonsters)
            => GetMonstersGroup(minMonsters, maxMonsters, minLevel, maxLevel, forbiddenMonsters, mandatoryMonsters).Count > 0;

        public List<MonstersGroupEntry> GetMonstersGroup(int minMonsters, int maxMonsters, int minLevel, int maxLevel, List<int> forbiddenMonsters, List<int> mandatoryMonsters)
        {
            var monstersGroups = new List<MonstersGroupEntry>();

            foreach (var monstersGroup in MonstersGroups)
            {
                // In case this group was blacklisted
                if (BlacklistedMonsters.Contains(monstersGroup.Id))
                    continue;

                if (monstersGroup.MonstersCount < minMonsters || monstersGroup.MonstersCount > maxMonsters)
                    continue;

                if (monstersGroup.TotalLevel < minLevel || monstersGroup.TotalLevel > maxLevel)
                    continue;

                bool valid = true;
                if (forbiddenMonsters != null)
                {
                    for (int i = 0; i < forbiddenMonsters.Count; i++)
                    {
                        if (monstersGroup.ContainsMonster(forbiddenMonsters[i]))
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                // Only check for mandatory monsters if the group passed the forbidden monsters test
                if (mandatoryMonsters != null && valid)
                {
                    for (int i = 0; i < mandatoryMonsters.Count; i++)
                    {
                        if (!monstersGroup.ContainsMonster(mandatoryMonsters[i]))
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                // If the group is still valid, then its the one!
                if (valid)
                {
                    monstersGroups.Add(monstersGroup);
                }
            }

            return monstersGroups;
        }

        public bool IsOnMap(string coords) => coords == Id.ToString() || coords == CurrentPosition;

        public PlayerEntry GetPlayer(int id)
        {
            if (PlayedCharacter?.Id == id)
                return PlayedCharacter;

            if (_players.TryGetValue(id, out PlayerEntry player))
                return player;

            return null;
        }

        public void Clear()
        {
            //_joinedFight = false;
            Data = null;
            Area = null;
            SubArea = null;
            PosX = 0;
            PosY = 0;
            _firstTime = true;
            RaisePropertyChanged("CurrentPosition");
        }

        #region Updates

        public async Task Update(MapComplementaryInformationsDataMessage message)
        {
            _account.Logger.LogDebug("", "Got MCIDM for map " + message.MapId);
            var sw = Stopwatch.StartNew();
            bool sameMap = Data != null && message.MapId == Id;
            Data = await MapsManager.GetMapAsync((int) message.MapId);
            var mp = DataManager.Get<MapPositions>(Id);
            var subArea = DataManager.Get<SubAreas>((int) message.SubAreaId);
            var area = DataManager.Get<Areas>(subArea.AreaId);

            // In case the account got disposed while we were getting the map's data
            if (_disposedValue)
                return;

            SubArea = subArea.NameId;
            Area = area.NameId;
            PosX = (sbyte) mp.PosX;
            PosY = (sbyte) mp.PosY;
            _account.Logger.LogDebug("", $"Got map infos [{CurrentPosition}] in {sw.Elapsed.TotalMilliseconds}ms.");
            RaisePropertyChanged("CurrentPosition");

            _doors.Clear();
            _players.Clear();
            _npcs.Clear();
            _monstersGroups.Clear();
            _interactives.Clear();
            _statedElements.Clear();
            _phenixs.Clear();
            _lockedStorages.Clear();
            TeleportableCells.Clear();
            BlacklistedMonsters.Clear();
            Zaap = null;

            // Entities
            foreach (var actor in message.Actors)
            {
                if (actor is GameRolePlayCharacterInformations player)
                {
                    if (player.ContextualId == _account.Game.Character.Id)
                    {
                        PlayedCharacter = new PlayerEntry(player);
                    }
                    else
                    {
                        _players.TryAdd(player.ContextualId, new PlayerEntry(player));
                    }
                }
                else if (actor is GameRolePlayMutantInformations mutant)
                {
                    if (mutant.ContextualId == _account.Game.Character.Id)
                    {
                        PlayedCharacter = new PlayerEntry(mutant);
                    }
                    else
                    {
                        _players.TryAdd(mutant.ContextualId, new PlayerEntry(mutant));
                    }
                }
                else if (actor is GameRolePlayNpcInformations npc)
                {
                    _npcs.TryAdd(npc.ContextualId, new NpcEntry(npc));
                }
                else if (actor is GameRolePlayGroupMonsterInformations monstersGroup)
                {
                    _monstersGroups.TryAdd(monstersGroup.ContextualId, new MonstersGroupEntry(monstersGroup));
                }
            }

            // Interactives
            message.InteractiveElements.ForEach(i => _interactives.TryAdd((int) i.ElementId, new InteractiveElementEntry(i)));
            message.StatedElements.ForEach(se => _statedElements.TryAdd((int) se.ElementId, new StatedElementEntry(se)));

            // Doors
            foreach (var kvp in Data.MidgroundLayer)
            {
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    // Check for teleportable cells
                    if (kvp.Value[i].g == 21000)
                    {
                        TeleportableCells.Add(kvp.Key);
                    }
                    // Check for other usable interactives (like doors)
                    else
                    {
                        var interactive = GetInteractiveElement(kvp.Value[i].Id);

                        if (interactive == null)
                            continue;

                        // Check if this element is a phenix (a phenix doesn't have skills that's why we check here)
                        if (kvp.Value[i].g == 7521)
                        {
                            _phenixs.TryAdd(kvp.Value[i].Id, new ElementInCellEntry(interactive, kvp.Key));
                        }

                        if (!interactive.Usable)
                            continue;

                        // Zaap
                        if (kvp.Value[i].g == 15363 || kvp.Value[i].g == 38003)
                        {
                            Zaap = new ElementInCellEntry(interactive, kvp.Key);
                        }
                        // Zaapi
                        else if (kvp.Value[i].g == 15004)
                        {
                            Zaapi = new ElementInCellEntry(interactive, kvp.Key);
                        }
                        // Locked storage
                        else if (kvp.Value[i].g == 12367)
                        {
                            _lockedStorages.TryAdd(kvp.Value[i].Id, new ElementInCellEntry(interactive, kvp.Key));
                        }
                        // Doors
                        else if (DoorsTypeIds.Contains(interactive.ElementTypeId) && DoorsSkillIds.Contains(interactive.EnabledSkills[0].Id))
                        {
                            _doors.TryAdd(kvp.Value[i].Id, new ElementInCellEntry(interactive, kvp.Key));
                        }
                    }
                }
            }

            // Only trigger the event when we actually changed the map
            // IDK why DT has this, but there is a possibility that we get a second MCIDM for the same map
            if (!sameMap || _joinedFight)
            {
                _joinedFight = false;
                _account.Logger.LogDebug("", "Triggering MapChanged;");
                MapChanged?.Invoke();

                if (_firstTime)
                {
                    _firstTime = false;
                    MapLoaded?.Invoke();
                }
            }
            else
            {
                _account.Logger.LogWarning("", "Same map.");
            }
        }

        public void Update(GameRolePlayShowActorMessage message)
        {
            if (message.Informations is GameRolePlayCharacterInformations player)
            {
                var pe = new PlayerEntry(player);
                _players.TryAdd(pe.Id, pe);
                PlayerJoined?.Invoke(pe);
                EntitiesUpdated?.Invoke();
            }
            else if (message.Informations is GameRolePlayMutantInformations mutant)
            {
                var pe = new PlayerEntry(mutant);
                _players.TryAdd(pe.Id, pe);
                PlayerJoined?.Invoke(pe);
                EntitiesUpdated?.Invoke();
            }
            else if (message.Informations is GameRolePlayGroupMonsterInformations monstersGroup)
            {
                _monstersGroups.TryAdd(monstersGroup.ContextualId, new MonstersGroupEntry(monstersGroup));
                EntitiesUpdated?.Invoke();
            }
        }

        public void Update(GameContextRemoveElementMessage message)
        {
            RemoveEntity(message.Id);
        }

        public void Update(GameContextRemoveMultipleElementsMessage message)
        {
            message.Id.ForEach(RemoveEntity);
        }

        public void Update(GameMapMovementMessage message)
        {
            var player = GetPlayer(message.ActorId);
            if (player != null)
            {
                player.Update(message);

                if (player == PlayedCharacter)
                {
                    PlayedCharacterMoving?.Invoke(message.KeyMovements.Select(c => (short) c).ToList());
                }
                else
                {
                    EntitiesUpdated?.Invoke();
                }
            }
            else if (_monstersGroups.TryGetValue(message.ActorId, out MonstersGroupEntry gm))
            {
                gm.Update(message);
                EntitiesUpdated?.Invoke();
            }
        }

        public void Update(InteractiveElementUpdatedMessage message)
        {
            _interactives.TryRemove((int) message.InteractiveElement.ElementId, out InteractiveElementEntry value);
            _interactives.TryAdd((int) message.InteractiveElement.ElementId, new InteractiveElementEntry(message.InteractiveElement));

            InteractivesUpdated?.Invoke();
        }

        public void Update(InteractiveMapUpdateMessage message)
        {
            _interactives.Clear();

            for (int i = 0; i < message.InteractiveElements.Count; i++)
            {
                _interactives.TryAdd((int) message.InteractiveElements[i].ElementId, new InteractiveElementEntry(message.InteractiveElements[i]));
            }

            InteractivesUpdated?.Invoke();
        }

        public void Update(StatedElementUpdatedMessage message)
        {
            _statedElements.TryRemove((int) message.StatedElement.ElementId, out StatedElementEntry value);
            _statedElements.TryAdd((int) message.StatedElement.ElementId, new StatedElementEntry(message.StatedElement));

            InteractivesUpdated?.Invoke();
        }

        public void Update(StatedMapUpdateMessage message)
        {
            _statedElements.Clear();

            for (int i = 0; i < message.StatedElements.Count; i++)
            {
                _statedElements.TryAdd((int) message.StatedElements[i].ElementId, new StatedElementEntry(message.StatedElements[i]));
            }

            InteractivesUpdated?.Invoke();
        }

        public void Update(GameFightJoinMessage message)
        {
            //_account.Logger.LogWarning("", "_joinedFight = true");
            _joinedFight = true;
        }

        #endregion

        private void RemoveEntity(int id)
        {
            var player = GetPlayer(id);
            if (player != null)
            {
                _players.TryRemove(id, out PlayerEntry value);
                PlayerLeft?.Invoke(player);
                EntitiesUpdated?.Invoke();
            }
            else if (_monstersGroups.TryRemove(id, out MonstersGroupEntry value))
            {
                EntitiesUpdated?.Invoke();
            }
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
                return;

            _players.Clear();
            _npcs.Clear();
            _interactives.Clear();
            _statedElements.Clear();
            _monstersGroups.Clear();
            _doors.Clear();
            _phenixs.Clear();
            _lockedStorages.Clear();
            TeleportableCells.Clear();
            BlacklistedMonsters.Clear();
            _players = null;
            _npcs = null;
            _interactives = null;
            _statedElements = null;
            _monstersGroups = null;
            _doors = null;
            _phenixs = null;
            _lockedStorages = null;
            TeleportableCells = null;
            SubArea = null;
            Area = null;
            Data = null;
            PlayedCharacter = null;
            BlacklistedMonsters = null;
            Zaap = null;
            Zaapi = null;
            _account = null;

            _disposedValue = true;
        }

        ~MapGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion
    }
}