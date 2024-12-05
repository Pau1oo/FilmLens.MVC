using FilmLens.AppServices.Movies.Repositories;
using FilmLens.AppServices.Users.Repositories;
using FilmLens.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;
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
        private readonly IMovieRepository _movieRepository;

        public UserService(UserManager<User> userManager, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
	}
}
