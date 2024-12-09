using Microsoft.AspNetCore.Identity;

namespace FilmLens.Domain.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Комментарии пользователя.
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = [];

        /// <summary>
        /// Избранные фильмы пользователя.
        /// </summary>
        public ICollection<FavoriteMovie> FavoriteMovies { get; set; } = [];
	}
}
