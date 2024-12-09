using FilmLens.Contracts.Common;

namespace FilmLens.Contracts.Movies
{
	public class MoviesListDto : PagedResponse<MovieDto>
	{
		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int? GenreId { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int? UserId { get; set; }
		
		/// <summary>
		/// Наименование жанра.
		/// </summary>
		public string? GenreName { get; set; }
	}
}
