using FilmLens.Contracts.Genres;

namespace FilmLens.AppServices.Genres.Services
{
	/// <summary>
	/// Интерфейс сервиса по работе с жанрами.
	/// </summary>
	public interface IGenreService
	{
		/// <summary>
		/// Получает список жанров фильма по его идентификатору.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellation">Токен отмены операции.</param>
		Task<List<GenreDto>> GetGenresAsync(int movieId, CancellationToken cancellation);
	}
}
