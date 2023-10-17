using CharacterCreatorApp.Models.TokenModels;

namespace CharacterCreatorApp.Services.TokenServices
{
    public interface ITokenService
    {
        Task<TokenResponse?> GetTokenAsync(TokenRequest model);
    }
}