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
        /// Количество рецензий, написанных пользователем.
        /// </summary>
        public int ReviewCount { get; set; } = default!;

        public ICollection<Review> Reviews { get; set; } = [];

        public ICollection<FavoriteMovie> FavoriteMovies { get; set; } = [];
	}
}
