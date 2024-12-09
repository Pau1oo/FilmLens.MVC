namespace FilmLens.Contracts.Reviews
{
	/// <summary>
	/// Транспортная модель рецензии.
	/// </summary>
	public sealed class ReviewDto
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
		/// Имя комментатора.
		/// </summary>
		public string ReviewerName { get; set; }

		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int ReviewedMovieId { get; set; }

		/// <summary>
		/// Наименование фильма.
		/// </summary>
		public string MovieTitle { get; set; }

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
