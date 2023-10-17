using System.ComponentModel.DataAnnotations;
using CharacterCreatorApp.Data.Entities;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;

namespace CharacterCreatorApp.Models.CharacterModels
{
    public class WarriorCharacterCreateList
    {
        [Key]
        public int CharacterId { get; set; }

        [Required, MaxLength(50), MinLength(4)]
        public string CharacterName { get; set; } = string.Empty;
        public string? HairColorSelection { get; set; } = string.Empty;
        public string? FaceStructureSelection { get; set; }
        public string? BodyTypeSelection { get; set; } = string.Empty;
        public string? HeightSelection { get; set; } = string.Empty;
        public string SpecialAbility { get; set; } = "Sword's Dance";

        public string SpecialStarterWeapon { get; set; } = "Warrior's Enhanced Iron Sword";

        public int WeaponSkill { get; set; } = 30;
    }
}