using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Users.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		/// <summary>
		/// Получает список пользователей по их идентификаторам.
		/// </summary>
		/// <param name="userIds">Идентификатор пользователя.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> userIds, CancellationToken cancellationToken);
	}
}
