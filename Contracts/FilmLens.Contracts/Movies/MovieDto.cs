using FilmLens.Contracts.Genres;
using FilmLens.Contracts.Reviews;

namespace FilmLens.Contracts.Movies
{
	/// <summary>
	/// Транспортная модель фильма.
	/// </summary>
	public sealed class MovieDto
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Описание.
		/// </summary>
		public string Overview { get; set; } = string.Empty;

		/// <summary>
		/// Дата релиза.
		/// </summary>
		public string ReleaseDate { get; set; }

		/// <summary>
		/// Средняя оценка.
		/// </summary>
		public double? VoteAverage { get; set; }

		/// <summary>
		/// Количество оценок.
		/// </summary>
		public int? VoteCount { get; set; }

		/// <summary>
		/// Ссылка на постер.
		/// </summary>
		public string? PosterUrl { get; set; }

		/// <summary>
		/// Лозунг фильма.
		/// </summary>
		public string? Tagline { get; set; }

		/// <summary>
		/// Продолжительность (в минутах).
		/// </summary>
		public int? Runtime { get; set; }

		/// <summary>
		/// Бюджет.
		/// </summary>
		public long? Budget { get; set; }

		/// <summary>
		/// Идентификатор фильма в TMDb.
		/// </summary>
		public string TmdbId { get; set; }

		/// <summary>
		/// Жанры фильма.
		/// </summary>
		public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();

		/// <summary>
		/// Рецензии фильма.
		/// </summary>
		public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
	}
}
