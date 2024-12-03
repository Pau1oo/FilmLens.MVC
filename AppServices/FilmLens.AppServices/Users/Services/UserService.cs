using FilmLens.AppServices.Users.Repositories;
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
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<User> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
	}
}
