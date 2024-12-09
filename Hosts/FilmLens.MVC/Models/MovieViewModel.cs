using FilmLens.Contracts.Genres;
using FilmLens.Contracts.Movies;
using FilmLens.Contracts.Reviews;

namespace FilmLens.MVC.Models
{
	/// <summary>
	/// Модель фильма.
	/// </summary>
	public class MovieViewModel
	{
		public ReviewViewModel Review { get; set; }

		public MovieDto Movie { get; set; }

		/// <summary>
		/// Флаг для проверки, в избранном ли фильм.
		/// </summary>
		public bool IsFavorite { get; set; }

		public List<GenreDto> Genres { get; set; }

		public List<ReviewDto> Reviews { get; set; }
	}
}
