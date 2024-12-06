namespace FilmLens.Contracts.Common
{
	/// <summary>
	/// Пагинированный запрос.
	/// </summary>
	public class PagedRequest
	{
		/// <summary>
		/// Количество на странице.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Номер страницы.
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int? GenreId { get; set; }

		/// <summary>
		/// Наименование жанра.
		/// </summary>
		public string? GenreName { get; set; }

		public int? UserId { get; set; }
	}
}
