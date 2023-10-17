using System.ComponentModel.DataAnnotations;
using CharacterCreatorApp.Data.Entities;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;

namespace CharacterCreatorApp.Models.CharacterModels
{
    public class WizardCharacterCreateList
    {
        [Key]
        public int CharacterId { get; set; }

        [Required, MaxLength(50), MinLength(4)]
        public string CharacterName { get; set; } = string.Empty;
        public string? HairColorSelection { get; set; } = string.Empty;
        public string? FaceStructureSelection { get; set; }
        public string? BodyTypeSelection { get; set; } = string.Empty;
        public string? HeightSelection { get; set; } = string.Empty;
        public  string SpecialAbility { get; set; } = "Nova Pulse";
        public string SpecialStarterWeapon { get; set; } = "Mage Beginner Staff";
        public int MagicSkill { get; set; } = 30;
    }
}