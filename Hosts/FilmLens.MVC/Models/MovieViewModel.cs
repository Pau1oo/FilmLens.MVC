using FilmLens.Contracts.Genres;
using FilmLens.Contracts.Movies;
using FilmLens.Domain.Entities;

namespace FilmLens.MVC.Models
{
	public class MovieViewModel
	{
		public CommonViewModel Common { get; set; }

		/// <summary>
		/// Фильм.
		/// </summary>
		public MovieDto Movie { get; set; }

		public List<GenreDto> Genres { get; set; }
	}
}
