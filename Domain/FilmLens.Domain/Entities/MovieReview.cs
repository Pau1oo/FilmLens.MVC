namespace FilmLens.Domain.Entities
{
	/// <summary>
	/// Связь фильма и рецензии.
	/// </summary>
	public sealed class MovieReview
	{
		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int MovieId { get; set; }

		/// <summary>
		/// Идентификатор рецензии.
		/// </summary>
		public int ReviewId { get; set; }
	}
}
