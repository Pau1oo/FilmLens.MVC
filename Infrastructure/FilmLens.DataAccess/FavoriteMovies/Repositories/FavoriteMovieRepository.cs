using FilmLens.AppServices.FavoriteMovies.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.FavoriteMovies.Repositories
{
	public sealed class FavoriteMovieRepository : EfRepositoryBase<FavoriteMovie>, IFavoriteMovieRepository
	{
		public FavoriteMovieRepository(
			MutableFilmLensDbContext mutableDbContext,
			ReadonlyFilmLensDbContext readOnlyDbContext)
			: base(mutableDbContext, readOnlyDbContext)
		{
		}

		public async Task<FavoriteMovie> GetFavoriteMovieAsync(int movieId, CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<FavoriteMovie>()
				.FirstOrDefaultAsync(fm => fm.MovieId == movieId, cancellationToken);
		}

		public async Task DeleteAsync(FavoriteMovie favoriteMovie, CancellationToken cancellationToken)
		{
			MutableDbContext.Set<FavoriteMovie>().Remove(favoriteMovie);

			await MutableDbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task<bool> ExistsAsync(int userId, int movieId)
		{
			return await ReadOnlyDbContext
				.Set<FavoriteMovie>()
				.AnyAsync(fm => fm.UserId == userId && fm.MovieId == movieId);
		}
	}
}
