using System.ComponentModel.DataAnnotations;

namespace FilmLens.MVC.Models
{
	public class AddMovieViewModel
	{
		/// <summary>
		/// ID фильма в TMDb.
		/// </summary>
		[Required]
		public int TmdbId { get; set; }

		/// <summary>
		/// Сообщение о результате операции.
		/// </summary>
		public string? Message { get; set; }
	}
}
