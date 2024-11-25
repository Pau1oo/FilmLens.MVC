using FilmLens.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FilmLens.AppServices.Users.Services
{
    /// <summary>
    /// Сервис по работе с пользователями.
    /// </summary>
    public sealed class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
    }
}
