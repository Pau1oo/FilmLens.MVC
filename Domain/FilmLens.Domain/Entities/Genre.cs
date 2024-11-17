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
        public string Name { get; set; } = default!;
    }
}
