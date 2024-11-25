using System.ComponentModel.DataAnnotations;

namespace FilmLens.MVC.Models
{
	public class CommonViewModel
	{
		/// <summary>
		/// ID фильма в TMDb.
		/// </summary>
		[Required]
		public int TmdbId { get; set; }
	}
}
