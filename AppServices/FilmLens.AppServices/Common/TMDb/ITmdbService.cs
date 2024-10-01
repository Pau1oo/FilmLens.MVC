using FilmLens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
