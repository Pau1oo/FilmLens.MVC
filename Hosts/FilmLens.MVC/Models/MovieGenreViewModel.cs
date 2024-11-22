using FilmLens.Contracts.Common;
using FilmLens.Contracts.Movies;
using FilmLens.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilmLens.MVC.Models
{
	public class MovieGenreViewModel : PagedResponse<MovieDto>
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

		/// <summary>
		/// Список жанров.
		/// </summary>
		public List<Genre> Genres { get; set; }
	}
}
