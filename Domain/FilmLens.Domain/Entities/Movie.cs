using Newtonsoft.Json;

namespace FilmLens.Domain.Entities
{
	/// <summary>
	/// Фильм.
	/// </summary>
	public sealed class Movie
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Описание.
		/// </summary>
		[JsonProperty("overview")]
		public string Overview { get; set; } = string.Empty;

		/// <summary>
		/// Дата релиза.
		/// </summary>
		[JsonProperty("release_date")]
		public string ReleaseDate { get; set; }

		/// <summary>
		/// Средняя оценка.
		/// </summary>
		[JsonProperty("vote_average")]
		public double? VoteAverage { get; set; }

		/// <summary>
		/// Количество оценок.
		/// </summary>
		[JsonProperty("vote_count")]
		public int? VoteCount { get; set; }

		/// <summary>
		/// Постер.
		/// </summary>
		[JsonProperty("poster_path")]
		public string? PosterUrl { get; set; }

		/// <summary>
		/// Лозунг фильма.
		/// </summary>
		[JsonProperty("tagline")]
		public string? Tagline { get; set; }

		/// <summary>
		/// Продолжительность (в минутах).
		/// </summary>
		[JsonProperty("runtime")]
		public int? Runtime { get; set; }

		/// <summary>
		/// Бюджет.
		/// </summary>
		[JsonProperty("budget")]
		public long? Budget { get; set; }

		/// <summary>
		/// Идентификатор фильма в TMDb.
		/// </summary>
		[JsonProperty("id")]
		public string TmdbId { get; set; }

		/// <summary>
		/// Жанры фильма.
		/// </summary>
		[JsonProperty("genres")]
		public ICollection<Genre> Genres { get; set; } = [];

		/// <summary>
		/// Рецензии фильма.
		/// </summary>
		public ICollection<Review> Reviews { get; set; } = [];
    }
}
