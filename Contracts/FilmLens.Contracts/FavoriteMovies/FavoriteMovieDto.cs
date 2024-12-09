namespace FilmLens.Contracts.FavoriteMovies
{
	/// <summary>
	/// Транспортная модель избранного фильма.
	/// </summary>
	public sealed class FavoriteMovieDto
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int MovieId { get; set; }
	}
}
