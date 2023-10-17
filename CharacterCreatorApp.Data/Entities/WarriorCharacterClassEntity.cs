using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CharacterCreatorApp.Data.Entities.CharacterCreationEnums;

namespace CharacterCreatorApp.Data.Entities
{
    public class WarriorCharacterClassEntity 
    {
        [Key]
        public int CharacterId { get; set; }

        [Required, MaxLength(50), MinLength(4)]
        public string CharacterName { get; set; } = string.Empty;

        public HairColor HairColor { get; set; } 
        public string? HairColorSelection { get; set; } = string.Empty;

        public FaceStructure FaceStructure { get; set; }
        public string? FaceStructureSelection { get; set; }

        public BodyType BodyType { get; set; }
        public string? BodyTypeSelection { get; set; } = string.Empty;

        public CharacterHeight Height { get; set; }
        public string? HeightSelection { get; set; } = string.Empty;
        public string SpecialAbility { get; set; } = "Sword's Dance";

        public string SpecialStarterWeapon { get; set; } = "Warrior's Enhanced Iron Sword";

        public int WeaponSkill { get; set; } = 30;

        public int UserId { get; set; }
        public UserEntity User { get; set; }

    }
}