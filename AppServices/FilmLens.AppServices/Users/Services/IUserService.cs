using FilmLens.Domain.Entities;
using System.Security.Claims;

namespace FilmLens.AppServices.Users.Services
{
    /// <summary>
    /// Интерфейс сервиса по работе с пользователями.
    /// </summary>
    public interface IUserService
    {
        Task<User> GetUserAsync(ClaimsPrincipal user);

       // Task<string> GetUserNameByIdAsync(int userId, CancellationToken cancellationToken);

	}
}
