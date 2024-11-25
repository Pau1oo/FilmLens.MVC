namespace FilmLens.Domain.Entities
{
	/// <summary>
	/// Связь пользователя и рецензии.
	/// </summary>
	public sealed class UserReview
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Идентификатор рецензии.
		/// </summary>
		public int ReviewId { get; set; }
	}
}
