namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Класс связи.
    /// </summary>
    public sealed class MovieGenre
    {
        /// <summary>
        /// Идентификатор фильма.
        /// </summary>
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        /// <summary>
        /// Идентификатор жанра.
        /// </summary>
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
