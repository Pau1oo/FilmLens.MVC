using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Common.TMDb
{
	public interface ITmdbService
	{
		/// <summary>
		/// Получает информацию о фильме по его идентификатору.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма в TMDb.</param>
		Task<Movie> GetMovieDetails(int movieId);

		/// <summary>
		/// Выполняет поиск фильмов по заданному запросу.
		/// </summary>
		/// <param name="query">Поисковый запрос.</param>
		Task<MovieSearchResults> SearchMovies(string query);
	}
}
