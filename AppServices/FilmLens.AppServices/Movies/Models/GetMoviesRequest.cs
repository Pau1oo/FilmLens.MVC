namespace FilmLens.AppServices.Movies.Models
{
	public sealed class GetMoviesRequest
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

		public int Take { get; set; }

		public int Skip { get; set; }
	}
}
