namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Актёр.
    /// </summary>
    public sealed class Actor
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Биография.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Ссылка на фото.
        /// </summary>
        public string? ImageUrl { get; set; }
    }
}
