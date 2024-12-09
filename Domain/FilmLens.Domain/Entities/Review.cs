namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Комментарий.
    /// </summary>
    public sealed class Review
    {
		/// <summary>
		/// Идентификатор комментария.
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
		/// Текст комментария.
		/// </summary>
		public string ReviewText { get; set; }

		/// <summary>
		/// Дата создания комментария.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Связь с фильмом.
		/// </summary>
		public Movie Movie { get; set; }

		/// <summary>
		/// Связь с пользователем.
		/// </summary>
		public User User { get; set; }
	}
}
