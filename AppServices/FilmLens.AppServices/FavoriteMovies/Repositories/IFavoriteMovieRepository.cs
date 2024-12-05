using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.FavoriteMovies.Repositories
{
	public interface IFavoriteMovieRepository : IRepository<FavoriteMovie>
	{
		Task<FavoriteMovie> GetFavoriteMovieAsync(int movieId, CancellationToken cancellationToken);

		Task DeleteAsync(FavoriteMovie favoriteMovie, CancellationToken cancellationToken);

		Task<bool> ExistsAsync(int userId, int movieId);
	}
}
