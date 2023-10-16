using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CharacterCreatorApp.Data.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(100)]

        public string Email { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? LastName { get; set; } = string.Empty;

    }
}