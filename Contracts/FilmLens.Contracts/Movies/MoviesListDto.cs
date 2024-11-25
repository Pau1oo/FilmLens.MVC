using FilmLens.Contracts.Common;
using FilmLens.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilmLens.Contracts.Movies
{
	public class MoviesListDto : PagedResponse<MovieDto>
	{
		/// <summary>
		/// ID фильма в TMDb.
		/// </summary>
		[Required]
		public int TmdbId { get; set; }

		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int? GenreId { get; set; }
		
		/// <summary>
		/// Наименование жанра.
		/// </summary>
		public string? GenreName { get; set; }

	}
}
