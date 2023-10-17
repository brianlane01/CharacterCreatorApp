using CharacterCreatorApp.Models.UserModels;
using CharacterCreatorApp.Models.CharacterModels;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;

namespace CharacterCreatorApp.Services.CharacterCreationServices
{
    public interface ICharacterCreationService
    {
        Task<RogueCharacterCreateList?> CreateRogueCharacterAsync(CharacterCreate request);
        Task<WarriorCharacterCreateList?> CreateWarriorCharacterAsync(CharacterCreate request);
        Task<WizardCharacterCreateList?> CreateWizardCharacterAsync(CharacterCreate request);
    }
}