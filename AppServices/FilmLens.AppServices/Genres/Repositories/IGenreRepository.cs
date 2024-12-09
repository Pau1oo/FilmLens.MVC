using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Genres.Repositories
{
	public interface IGenreRepository : IRepository<Genre>
	{
		/// <summary>
		/// Получает список жанров по их идентификаторам.
		/// </summary>
		/// <param name="ids">Идентификаторы жанров.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<Genre>> GetGenresByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);

		/// <summary>
		/// Получает список всех жанров.
		/// </summary>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken);

		/// <summary>
		/// Получает список жанров фильма по его идентификатору.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<Genre>> GetGenresByMovieIdAsync(int movieId, CancellationToken cancellationToken);
	}
}
