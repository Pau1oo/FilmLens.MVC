using System.ComponentModel.DataAnnotations;

namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Жанр.
    /// </summary>
    public sealed class Genre
    {
        /// <summary>
        /// Идентификатор жанра.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование жанра.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Связь с фильмами.
        /// </summary>
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
