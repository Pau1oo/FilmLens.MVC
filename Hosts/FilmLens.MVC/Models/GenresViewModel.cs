using FilmLens.Domain.Entities;

namespace FilmLens.MVC.Models
{
	public class GenresViewModel : CommonViewModel
	{
		/// <summary>
		/// Список жанров.
		/// </summary>
		public List<Genre> Genres { get; set; }
	}
}
