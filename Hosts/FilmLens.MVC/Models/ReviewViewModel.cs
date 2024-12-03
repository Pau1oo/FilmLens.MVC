namespace FilmLens.MVC.Models
{
	public class ReviewViewModel : CommonViewModel	
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int ReviewerUserId { get; set; }

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
