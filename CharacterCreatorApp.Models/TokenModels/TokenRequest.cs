using System.ComponentModel.DataAnnotations;

namespace CharacterCreatorApp.Models.TokenModels
{
    public class TokenRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}