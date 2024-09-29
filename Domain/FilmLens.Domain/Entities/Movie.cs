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
        [Required]
        [StringLength(255)]
        public string Title { get; set; } = default!;

        /// <summary>
        /// Описание.
        /// </summary>
        public string? Description { get; set; }

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
    }
}
