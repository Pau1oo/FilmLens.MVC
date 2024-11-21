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

		public async Task<List<Genre>> GetGenresByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<Genre>()
				.Where(g => ids.Contains(g.Id))
				.ToListAsync(cancellationToken);
		}

		public async Task DeleteGenresByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
		{
			// Найти жанры по идентификаторам
			var genresToDelete = await MutableDbContext
				.Set<Genre>()
				.Where(g => ids.Contains(g.Id))
				.ToListAsync(cancellationToken);

			// Удалить найденные жанры
			MutableDbContext.Set<Genre>().RemoveRange(genresToDelete);

			// Сохранить изменения в базе данных
			await MutableDbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<Genre>()
				.ToListAsync(cancellationToken);
		}

		public async Task AddGenresAsync(IEnumerable<Genre> genres, CancellationToken cancellationToken)
		{
			await MutableDbContext.AddRangeAsync(genres, cancellationToken);
			await MutableDbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
