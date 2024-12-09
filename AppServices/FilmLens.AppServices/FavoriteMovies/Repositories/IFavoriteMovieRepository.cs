using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.FavoriteMovies.Repositories
{
	public interface IFavoriteMovieRepository : IRepository<FavoriteMovie>
	{
		/// <summary>
		/// Получает сущность фильма из списка избранных по его идентификатору.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		/// <returns></returns>
		Task<FavoriteMovie> GetFavoriteMovieAsync(int movieId, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет фильм из списка избранных пользователя.
		/// </summary>
		/// <param name="favoriteMovie">Сущность фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		/// <returns></returns>
		Task DeleteAsync(FavoriteMovie favoriteMovie, CancellationToken cancellationToken);

		/// <summary>
		/// Проверяет наличие фильма в списке избранных пользователя.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <returns></returns>
		Task<bool> ExistsAsync(int userId, int movieId);
	}
}
