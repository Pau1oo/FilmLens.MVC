using FilmLens.Domain.Entities;
using System.Security.Claims;

namespace FilmLens.AppServices.Users.Services
{
    /// <summary>
    /// Интерфейс сервиса по работе с пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получает сущность пользователя.
        /// </summary>
        /// <param name="user">Сущность пользователя.</param>
        Task<User> GetUserAsync(ClaimsPrincipal user);
	}
}
