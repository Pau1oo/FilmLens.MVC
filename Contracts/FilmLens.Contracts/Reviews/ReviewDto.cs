namespace FilmLens.Contracts.Reviews
{
	/// <summary>
	/// Транспортная модель рецензии.
	/// </summary>
	public sealed class ReviewDto
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Идентификатор фильма.
		/// </summary>
		public int MovieId { get; set; }

		/// <summary>
		/// Текст рецензии.
		/// </summary>
		public string ReviewText { get; set; }

		/// <summary>
		/// Значение оценки.
		/// </summary>
		public int? RatingValue { get; set; }

		/// <summary>
		/// Дата создания рецензии.
		/// </summary>
		public DateTime CreatedAt { get; set; }
	}
}
