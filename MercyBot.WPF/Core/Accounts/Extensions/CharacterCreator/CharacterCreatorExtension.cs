using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations;
using MercyBot.Configurations.Language;
using MercyBot.Core.Accounts.Configurations;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration;
using MercyBot.Core.Accounts.InGame.Managers.Movements;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Messages.Messages;
using MercyBot.Protocol.Types;
using MercyBot.Utility;
using MercyBot.Utility.DofusTouch;

namespace MercyBot.Core.Accounts.Extensions.CharacterCreator
{
    public class CharacterCreatorExtension : IClearable, IDisposable
    {

        // Fields
        private Account _account;
        private TaskCompletionSource<string> _nameTcs;
        private bool _created;
        private bool _inTutorial;
        private QuestActiveDetailedInformations _currentStep;
        private uint _currentStepNumber;
        private int _currentItemIndex;


        // Properties
        public bool IsDoingTutorial => _inTutorial && _currentStep != null;


        // Constructor
        public CharacterCreatorExtension(Account account)
        {
            _account = account;

            _account.Game.Npcs.QuestionReceived += Npcs_QuestionReceived;
            _account.Game.Character.Inventory.ObjectEquipped += Inventory_ObjectEquipped;
            _account.Game.Map.MapChanged += Map_MapChanged;
            _account.Game.Managers.Movements.MovementFinished += Movements_MovementFinished;
        }


        private void ProcessTutorialSteps()
        {
            if (!IsDoingTutorial)
                return;

            _account.Logger.LogDebug(LanguageManager.Translate("516"), LanguageManager.Translate("517", _currentStepNumber));

            switch (_currentStepNumber)
            {
                // Step 1: Move in the map
                case 1:
                    _account.Game.Managers.Movements.MoveToCell(259);
                    break;
                // Step 2: Talk and reply to npc
                case 2:
                    _account.Game.Npcs.UseNpc(-1, 1);
                    break;
                // Step 3: Equip first item
                case 3:
                    _account.Game.Character.Inventory.EquipObject(_account.Game.Character.Inventory.GetObjectByGID(TutorialHelper.FirstEquipItem));
                    break;
                // Step 4: Change map to the right
                case 4:
                    _account.Game.Managers.Movements.ChangeMap(MapChangeDirections.RIGHT);
                    break;
                // Step 5: Start fight
                case 5:
                    _account.Game.Managers.Movements.MoveToCell(_account.Game.Map.MonstersGroups.First().CellId);
                    break;
                // Step 6: Change fight placement
                case 6:
                    var cells = _account.Game.Fight.PositionsForChallengers.Except(new[] { _account.Game.Fight.PlayedFighter.CellId }).ToArray();
                    _account.Network.SendMessage(new GameFightPlacementPositionRequestMessage((uint)cells[Randomize.GetRandomInt(0, cells.Length)]));
                    break;
                // Step 11: Equip second items
                case 11:
                    _currentItemIndex = 0;
                    _account.Game.Character.Inventory.EquipObject(_account.Game.Character.Inventory.GetObjectByGID(TutorialHelper.SecondEquipItems[_currentItemIndex]));
                    break;
                // Step 12: Change map to the right
                case 12:
                    _account.Game.Managers.Movements.ChangeMap(MapChangeDirections.RIGHT);
                    break;
            }
        }

        private void ValidateCurrentStep()
        {
            if (!IsDoingTutorial)
                return;

            _account.Logger.LogDebug(LanguageManager.Translate("516"), LanguageManager.Translate("518", _currentStepNumber));
            for (int i = 0; i < _currentStep.Objectives.Count; i++)
            {
                _account.Network.SendMessage(new QuestObjectiveValidationMessage(_currentStep.QuestId, _currentStep.Objectives[i].ObjectiveId));
            }
        }

        private void Npcs_QuestionReceived()
        {
            if (!IsDoingTutorial)
                return;

            // Step 2: Reply to npc
            if (_currentStepNumber == 2 || _currentStepNumber == 10 || _currentStepNumber == 14)
            {
                _account.Game.Npcs.Reply(-1);
            }
        }

        private async void Inventory_ObjectEquipped(uint gid)
        {
            if (!IsDoingTutorial)
                return;

            // Step 3: Equip first item
            if (_currentStepNumber == 3 && gid == TutorialHelper.FirstEquipItem)
            {
                ValidateCurrentStep();
            }
            // Step 11: Equip second items
            else if (_currentStepNumber == 11 && gid == TutorialHelper.SecondEquipItems[_currentItemIndex])
            {
                _currentItemIndex++;

                if (_currentItemIndex == TutorialHelper.SecondEquipItems.Length)
                {
                    ValidateCurrentStep();
                }
                else
                {
                    await Task.Delay(600);
                    _account.Game.Character.Inventory.EquipObject(_account.Game.Character.Inventory.GetObjectByGID(TutorialHelper.SecondEquipItems[_currentItemIndex]));
                }
            }
        }

        private async void Map_MapChanged()
        {
            if (!IsDoingTutorial)
                return;

            // Step 10: talk and reply to npc
            if (_currentStepNumber == 10 && _account.Game.Map.Id == TutorialHelper.TutorialMapIdSecondAfterFight)
            {
                await Task.Delay(1600);
                _account.Game.Npcs.UseNpc(-1, 1);
            }
            else if (_currentStepNumber == 14 && _account.Game.Map.Id == TutorialHelper.TutorialMapIdThirdAfterFight)
            {
                await Task.Delay(1200);

                // Buy the shield
                await _account.Network.SendMessageAsync(new QuestObjectiveValidationMessage(1461, 8078));
                await Task.Delay(1200);

                // Equip hat and shield
                _account.Game.Character.Inventory.EquipObject(_account.Game.Character.Inventory.GetObjectByGID(10798));
                _account.Game.Character.Inventory.EquipObject(_account.Game.Character.Inventory.GetObjectByGID(10801));
                await Task.Delay(400);

                // Then talk to the npc
                _account.Game.Npcs.UseNpc(-1, 1);
            }

            // Step 12: Start fight
            if (_currentStepNumber == 12 && _account.Game.Map.Id == TutorialHelper.TutorialMapIdThirdBeforeFight)
            {
                _account.Game.Managers.Movements.MoveToCell(_account.Game.Map.MonstersGroups.First().CellId);
            }
        }

        private void Movements_MovementFinished(bool success)
        {
            if (!success)
                return;

            var mg = _account.Game.Map.MonstersGroups.FirstOrDefault();

            if (mg != null && mg.CellId == _account.Game.Map.PlayedCharacter.CellId)
            {
                _account.Network.SendMessage(new GameRolePlayAttackMonsterRequestMessage(mg.Id));
            }
        }

        public void Clear()
        {
            _created = false;
            _inTutorial = false;
            _nameTcs = null;
            _currentStep = null;
            _currentStepNumber = 0;
            _currentItemIndex = 0;
        }

        #region Updates

        public async Task Update(CharactersListMessage message)
        {
            if (!_account.AccountConfig.CharacterCreation.Create)
                return;

            // If the character has been successfuly created
            if (_created)
            {
                // Set Create to false so that we don't create a character each time we connect
                _account.AccountConfig.CharacterCreation.Create = false;
                GlobalConfiguration.Instance.Save();

                // Copy configurations if asked for
                try
                {
                    if (!string.IsNullOrEmpty(_account.AccountConfig.CharacterCreation.ParametersToCopy))
                    {
                        File.Copy(Path.Combine(Configuration.ConfigurationsPath, _account.AccountConfig.CharacterCreation.ParametersToCopy),
                            Path.Combine(Configuration.ConfigurationsPath, $"{_account.AccountConfig.Username}_{message.Characters[0].Name}.config"), overwrite: true);
                        _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("519"));
                    }
                    if (!string.IsNullOrEmpty(_account.AccountConfig.CharacterCreation.FightsConfigurationToCopy))
                    {
                        File.Copy(Path.Combine(FightsConfiguration.ConfigurationsPath, _account.AccountConfig.CharacterCreation.FightsConfigurationToCopy),
                            Path.Combine(FightsConfiguration.ConfigurationsPath, $"{_account.AccountConfig.Username}_{message.Characters[0].Name}.fconfig"), overwrite: true);
                        _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("520"));
                    }
                }
                catch (Exception ex)
                {
                    _account.Logger.LogError(LanguageManager.Translate("516"), ex.ToString());
                }

                _account.Logger.LogDebug(LanguageManager.Translate("516"), LanguageManager.Translate("521", message.Characters[0].Name));
                _account.Network.SendMessage(new CharacterFirstSelectionMessage((int)message.Characters[0].Id, true));
                return;
            }

            _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("522"));
            string name = _account.AccountConfig.CharacterCreation.Name;
            int breed = _account.AccountConfig.CharacterCreation.Breed == -1 ? Randomize.GetRandomInt(1, BreedsUtility.Breeds.Max(b => b.Id) + 1) : _account.AccountConfig.CharacterCreation.Breed;
            bool sex = (_account.AccountConfig.CharacterCreation.Sex == -1 ? Randomize.GetRandomInt(0, 2) : _account.AccountConfig.CharacterCreation.Sex) == 1;
            int headOrder = _account.AccountConfig.CharacterCreation.Head == -1 ? Randomize.GetRandomInt(0, 8) : _account.AccountConfig.CharacterCreation.Head;

            // If the user wanted a random name, use DT's random name generator
            if (name == "")
            {
                _account.Logger.LogDebug(LanguageManager.Translate("516"), LanguageManager.Translate("523"));
                _nameTcs = new TaskCompletionSource<string>();
                _account.Network.SendMessage(new CharacterNameSuggestionRequestMessage());
                _nameTcs.Task.Wait();
                name = _nameTcs.Task.Result;
                _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("524", name));
            }

            await Task.Delay(1000);
            // Send the character creation request message, take in consideration random stuff to generate
            _account.Network.SendMessage(new CharacterCreationRequestMessage(name, breed, sex, (uint)BreedsUtility.GetCosmeticId(breed, sex, headOrder), _account.AccountConfig.CharacterCreation.Colors));
        }

        public void Update(CharacterNameSuggestionSuccessMessage message)
        {
            _nameTcs.SetResult(message.Suggestion);
        }

        public async Task Update(CharacterCreationResultMessage message)
        {
            var result = (CharacterCreationResultEnum)message.Result;

            if (result == CharacterCreationResultEnum.OK)
            {
                _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("525"));
                _created = true;
            }
            else if (result == CharacterCreationResultEnum.ERR_NAME_ALREADY_EXISTS)
            {
                _account.Logger.LogWarning(LanguageManager.Translate("516"), LanguageManager.Translate("526", result));
                await Task.Delay(1000);
                await Update(new CharactersListMessage());
            }
            else
            {
                _account.Logger.LogError(LanguageManager.Translate("516"), LanguageManager.Translate("526", result));
            }
        }

        public void Update(QuestStartedMessage message)
        {
            if (!_account.AccountConfig.CharacterCreation.CompleteTutorial)
                return;

            if (message.QuestId != TutorialHelper.QuestTutorialId || !_created)
                return;

            _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("527"));
            _inTutorial = true;
            _account.Network.SendMessage(new QuestStepInfoRequestMessage(TutorialHelper.QuestTutorialId));
        }

        public async Task Update(QuestStepInfoMessage message)
        {
            if (!_inTutorial)
                return;

            if (_currentStep != null && _currentStep.StepId == ((QuestActiveDetailedInformations)message.Infos).StepId)
                return;

            _currentStep = message.Infos as QuestActiveDetailedInformations;
            _currentStepNumber++;

            await Task.Delay(2000);
            ProcessTutorialSteps();
        }

        public void Update(QuestStepValidatedMessage message)
        {
            if (!IsDoingTutorial || message.QuestId != TutorialHelper.QuestTutorialId)
                return;

            _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("528", _currentStepNumber));
            _account.Network.SendMessage(new QuestStepInfoRequestMessage(TutorialHelper.QuestTutorialId));
        }

        public void Update(GameMapMovementMessage message)
        {
            if (!IsDoingTutorial || message.ActorId != _account.Game.Character.Id)
                return;

            if (_currentStepNumber != 1 && _currentStepNumber != 7)
                return;

            ValidateCurrentStep();
        }

        public void Update(GameFightStartingMessage message)
        {
            if (!IsDoingTutorial)
                return;

            if (_currentStepNumber == 5 || _currentStepNumber == 12)
            {
                ValidateCurrentStep();
            }
        }

        public async Task Update(GameEntitiesDispositionMessage message)
        {
            if (!IsDoingTutorial)
                return;

            if (_currentStepNumber == 6)
            {
                ValidateCurrentStep();
                await Task.Delay(1000);
                _account.Network.SendMessage(new GameFightReadyMessage(true));
            }
        }

        public void Update(GameActionFightSpellCastMessage message)
        {
            if (!IsDoingTutorial || message.SourceId != _account.Game.Character.Id)
                return;

            if (_currentStepNumber == 8)
            {
                ValidateCurrentStep();
            }
        }

        public void Update(QuestValidatedMessage message)
        {
            if (!IsDoingTutorial || message.QuestId != TutorialHelper.QuestTutorialId)
                return;

            _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("528", _currentStepNumber));
            _account.Logger.LogInfo(LanguageManager.Translate("516"), LanguageManager.Translate("529"));
            _account.AccountConfig.CharacterCreation.CompleteTutorial = false;
            _inTutorial = false;
            _currentStep = null;
        }

        #endregion

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _account = null;

                _disposedValue = true;
            }
        }

        public void Dispose()
            => Dispose(true);

        #endregion
    }
}
