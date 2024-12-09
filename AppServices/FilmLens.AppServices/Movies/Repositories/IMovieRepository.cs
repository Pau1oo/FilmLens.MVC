using FilmLens.AppServices.Common;
using FilmLens.AppServices.Movies.Models;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Movies.Repositories
{
	public interface IMovieRepository : IRepository<Movie>
	{
		/// <summary>
		/// Получает список фильмов для пагинируемой страницы.
		/// </summary>
		/// <param name="request">Запрос.</param>
		/// <param name="cancellation">Токен отмены операции.</param>
		Task<List<Movie>> GetMoviesAsync(GetMoviesRequest request, CancellationToken cancellation);

		/// <summary>
		/// Получает полное кол-во фильмов в зависимости от параметра.
		/// </summary>
		/// <param name="genreId">Идентификатор жанра.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="cancellation">Токен отмены операции.</param>
		Task<int> GetMoviesTotalCountAsync(int? genreId, int? userId, CancellationToken cancellation);

		/// <summary>
		/// Получает фильм по его идентификатору.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<Movie> GetMovieAsync(int movieId, CancellationToken cancellationToken);

		/// <summary>
		/// Получает список фильмов по их идентификаторам.
		/// </summary>
		/// <param name="movieIds">Идентификаторы.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<Movie>> GetMoviesByIdsAsync(IEnumerable<int> movieIds, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет фильм из базы данных.
		/// </summary>
		/// <param name="movie">Сущность фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task DeleteAsync(Movie movie, CancellationToken cancellationToken);
	}
}
