using System.ComponentModel.DataAnnotations;

namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Рецензия.
    /// </summary>
    public sealed class Review
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// Идентификатор фильма.
        /// </summary>
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        /// <summary>
        /// Текст рецензии.
        /// </summary>
        [Required]
        public string ReviewText { get; set; }

        /// <summary>
        /// Дата создания рецензии.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
