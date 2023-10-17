using System.ComponentModel.DataAnnotations;
using CharacterCreatorApp.Data.Entities;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;

namespace CharacterCreatorApp.Models.CharacterModels
{
    public class RogueCharacterCreateList
    {
        [Key]
        public int CharacterId { get; set; }

        [Required, MaxLength(50), MinLength(4)]
        public string CharacterName { get; set; } = string.Empty;
        public string? HairColorSelection { get; set; } = string.Empty;
        public string? FaceStructureSelection { get; set; }
        public string? BodyTypeSelection { get; set; } = string.Empty;
        public string? HeightSelection { get; set; } = string.Empty;
        public string SpecialAbility { get; set; } = "Invisibility";
        public string SpecialStarterWeapon { get; set; } = "Rogue's Beginner SharpShot Bow";
        public int SneakSkill { get; set; } = 30; 

    }
}