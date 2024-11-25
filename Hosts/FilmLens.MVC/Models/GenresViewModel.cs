using FilmLens.Domain.Entities;

namespace FilmLens.MVC.Models
{
	public class GenresViewModel
	{
		public CommonViewModel Common { get; set; }

		/// <summary>
		/// Список жанров.
		/// </summary>
		public List<Genre> Genres { get; set; }
	}
}
