namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Класс связи.
    /// </summary>
    public sealed class MovieActor
    {
        /// <summary>
        /// Идентификатор фильма.
        /// </summary>
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        /// <summary>
        /// Идентификатор актёра.
        /// </summary>
        public int ActorId { get; set; }
        public Actor Actor { get; set; }


    }
}
