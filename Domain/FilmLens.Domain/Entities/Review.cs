namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Рецензия.
    /// </summary>
    public sealed class Review
    {
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int ReviewerUserId { get; set; }

		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int ReviewedMovieId { get; set; }

		/// <summary>
		/// Текст рецензии.
		/// </summary>
		public string ReviewText { get; set; }

		/// <summary>
		/// Дата создания рецензии.
		/// </summary>
		public DateTime CreatedAt { get; set; }
	}
}
