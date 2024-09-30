using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public sealed class User : IdentityUser<int>
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// Хэш пароля.
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Связь с ролями.
        /// </summary>
        public Role Role { get; set; }
    }
}
