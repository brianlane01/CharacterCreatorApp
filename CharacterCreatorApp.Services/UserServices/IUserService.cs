using CharacterCreatorApp.Models.UserModels;

namespace CharacterCreatorApp.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<UserDetail?> GetUserByIdAsync(int userId);
    }
}