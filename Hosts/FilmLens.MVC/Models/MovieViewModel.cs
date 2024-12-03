using FilmLens.Contracts.Genres;
using FilmLens.Contracts.Movies;
using FilmLens.Contracts.Reviews;

namespace FilmLens.MVC.Models
{
	public class MovieViewModel : CommonViewModel
	{
		public ReviewViewModel Review { get; set; }

		public MovieDto Movie { get; set; }

		public List<GenreDto> Genres { get; set; }

		public List<ReviewDto> Reviews { get; set; }
	}
}
