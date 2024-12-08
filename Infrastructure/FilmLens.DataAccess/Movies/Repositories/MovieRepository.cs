using FilmLens.AppServices.Movies.Models;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.Movies.Repositories
{
	public sealed class MovieRepository : EfRepositoryBase<Movie>, IMovieRepository
	{
        public MovieRepository(
            MutableFilmLensDbContext mutableDbContext,
            ReadonlyFilmLensDbContext readOnlyDbContext)
            : base(mutableDbContext, readOnlyDbContext)
        { 
        }

		/// <inheritdoc/>
		public async override Task<List<Movie>> GetAllAsync(CancellationToken cancellation)
		{
			return await ReadOnlyDbContext.Set<Movie>()
				.Include(x => x.Genres)
				.ToListAsync(cancellation);
		}

		public Task<int> GetMoviesTotalCountAsync(int? genreId, int? userId, CancellationToken cancellation)
		{
			var query = ReadOnlyDbContext
				.Set<Movie>()
				.AsQueryable();

			if (genreId.HasValue)
			{
				query = query.Where(movie => movie.Genres.Any(genre => genre.Id == genreId.Value));
			}
			else if (userId.HasValue)
			{
				query = query.Where(movie => movie.FavoriteByUsers.Any(fav => fav.UserId == userId.Value));
			}

			return query.CountAsync(cancellation);
		}

		public Task<List<Movie>> GetMoviesAsync(GetMoviesRequest request, CancellationToken cancellation)
		{
			var query = ReadOnlyDbContext
				.Set<Movie>()
				.AsQueryable();

			if (request.GenreId.HasValue)
			{
				query = query.Where(movie => movie.Genres.Any(genre => genre.Id == request.GenreId.Value));
			}
			else if(request.UserId.HasValue)
			{
				query = query.Where(movie => movie.FavoriteByUsers.Any(fav => fav.UserId == request.UserId.Value));
			}

			query = query
				.OrderBy(x => x.Id)
				.Skip(request.Skip);

			if (request.Take != default)
			{
				query = query.Take(request.Take);
			}

			return query.ToListAsync(cancellation);
		}

		public async Task<Movie> GetMovieAsync(int movieId, CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<Movie>()
				.FirstOrDefaultAsync(m => m.Id == movieId, cancellationToken);
		}

		public async Task<List<Movie>> GetMoviesByIdsAsync(IEnumerable<int> movieIds, CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<Movie>()
				.Where(u => movieIds.Contains(u.Id))
				.ToListAsync(cancellationToken);
		}

		public async Task DeleteAsync(Movie movie, CancellationToken cancellationToken)
		{
			MutableDbContext.Set<Movie>().Remove(movie);

			await MutableDbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
