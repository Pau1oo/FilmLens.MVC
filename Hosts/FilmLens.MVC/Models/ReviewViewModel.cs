namespace FilmLens.MVC.Models
{
	/// <summary>
	/// Модель комментария.
	/// </summary>
	public class ReviewViewModel
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int ReviewerUserId { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string ReviewerName { get; set; }

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
