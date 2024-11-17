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
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Overview { get; set; } = string.Empty;

        /// <summary>
        /// Дата релиза.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

		/// <summary>
		/// Средняя оценка.
		/// </summary>
		public double? VoteAverage { get; set; }

		/// <summary>
		/// Количество оценок.
		/// </summary>
		public int? VoteCount { get; set; }

		/// <summary>
		/// Постер.
		/// </summary>
		public string? PosterPath { get; set; }

		/// <summary>
		/// Ссылка на трейлер.
		/// </summary>
		public string? TrailerUrl { get; set; }

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
        public ICollection<Genre> Genres { get; set; } = [];

		/// <summary>
		/// Рецензии фильма.
		/// </summary>
		public ICollection<Review> Reviews { get; set; } = [];
    }
}
