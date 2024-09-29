using System.ComponentModel.DataAnnotations;

namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public sealed class Role
    {
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Связь с пользователями.
        /// </summary>
        public ICollection<User> Users { get; set; }
    }
}
