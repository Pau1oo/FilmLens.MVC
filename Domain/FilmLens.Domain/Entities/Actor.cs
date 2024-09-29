using System.ComponentModel.DataAnnotations;

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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Биография.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Ссылка на фото.
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Связь с фильмами.
        /// </summary>
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
