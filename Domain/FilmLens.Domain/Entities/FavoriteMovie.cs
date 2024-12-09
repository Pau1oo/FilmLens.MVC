namespace FilmLens.Domain.Entities
{
	/// <summary>
	/// Избранный фильм.
	/// </summary>
	public sealed class FavoriteMovie
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Связь с пользователем.
		/// </summary>
		public User User { get; set; } = default!;

		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int MovieId { get; set; }

		/// <summary>
		/// Связь с фильмом.
		/// </summary>
		public Movie Movie { get; set; } = default!;
	}
}
