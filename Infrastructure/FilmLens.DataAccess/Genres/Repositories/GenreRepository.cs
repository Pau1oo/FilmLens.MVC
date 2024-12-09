using FilmLens.AppServices.Genres.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.Genres.Repositories
{
	public sealed class GenreRepository : EfRepositoryBase<Genre>, IGenreRepository
	{
        public GenreRepository(
            MutableFilmLensDbContext mutableDbContext,
            ReadonlyFilmLensDbContext readOnlyDbContext)
            : base(mutableDbContext, readOnlyDbContext)
        {
        }

		/// <inheritdoc/>
		public async Task<List<Genre>> GetGenresByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<Genre>()
				.Where(g => ids.Contains(g.Id))
				.ToListAsync(cancellationToken);
		}

		/// <inheritdoc/>
		public async Task<List<Genre>> GetGenresByMovieIdAsync(int movieId, CancellationToken cancellationToken)
		{
			var genres = await ReadOnlyDbContext
				.Set<Movie>()
				.Where(m => m.Id == movieId)
				.SelectMany(m => m.Genres)
				.ToListAsync(cancellationToken);

			return genres;
		}

		/// <inheritdoc/>
		public async Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<Genre>()
				.ToListAsync(cancellationToken);
		}
	}
}
