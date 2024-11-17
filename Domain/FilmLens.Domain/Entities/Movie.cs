using System.ComponentModel.DataAnnotations;

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
        public string Title { get; set; } = default!;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Дата релиза.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Ссылка на постер.
        /// </summary>
        public string? PosterUrl { get; set; }

        /// <summary>
        /// Ссылка на трейлер.
        /// </summary>
        public string? TrailerUrl { get; set; }

        /// <summary>
        /// Идентификатор фильма в TMDb.
        /// </summary>
        public string TmdbId { get; set; }

        /// <summary>
        /// Жанры фильма.
        /// </summary>
        public ICollection<Genre> Genres { get; set; } = [];

        /// <summary>
        /// Актеры фильма.
        /// </summary>
        public ICollection<Actor> Actors { get; set; } = [];

		/// <summary>
		/// Значение оценки.
		/// </summary>
		public double? CriticsRating { get; set; }

		/// <summary>
		/// Рецензии фильма.
		/// </summary>
		public ICollection<Review> Reviews { get; set; } = [];
    }
}
