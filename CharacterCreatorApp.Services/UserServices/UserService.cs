using CharacterCreatorApp.Models.UserModels;
using CharacterCreatorApp.Data.Entities;
using CharacterCreatorApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CharacterCreatorApp.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserService(ApplicationDbContext dbContext,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {  
            if(await CheckUserNameAvailability(model.UserName) == false)
            {
                System.Console.WriteLine("UserName already taken please try again");
                return false; 
            }

            UserEntity entity = new UserEntity()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateCreated = DateTime.Now
            };

            IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

            return registerResult.Succeeded;
        }

        private async Task<bool> CheckUserNameAvailability(string userName)
        {
            UserEntity? existingUser = await _userManager.FindByNameAsync(userName);
            return existingUser is null;
        }

        public async Task<UserDetail?> GetUserByIdAsync(int userId)
        {
            UserEntity? entity = await _dbContext.Users.FindAsync(userId);
            if(entity is null)
                return null;
            
            UserDetail detail = new UserDetail()
            {
                Id = entity.Id,
                UserName = entity.UserName!,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateCreated = entity.DateCreated
            };

            return detail;
        }

    }
}