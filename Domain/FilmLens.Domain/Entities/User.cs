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

        public ICollection<Review> Reviews { get; set; } = [];

        public ICollection<FavoriteMovie> FavoriteMovies { get; set; } = [];
	}
}
