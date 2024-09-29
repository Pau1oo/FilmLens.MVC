using System;
using System.ComponentModel.DataAnnotations;

namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Оценка.
    /// </summary>
    public sealed class Rating
    {
        /// <summary>
        /// Идентификатор оценки.
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
        /// Значение оценки.
        /// </summary>
        [Range(1,10)]
        public int RatingValue { get; set; }

        /// <summary>
        /// Дата оценки.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
