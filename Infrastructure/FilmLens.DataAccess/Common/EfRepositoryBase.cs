using FilmLens.AppServices.Common;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.Common
{
	/// <summary>
	/// Базовый репозиторий для работы с БД через EF.
	/// </summary>
	public class EfRepositoryBase<T> : IRepository<T> where T : class
	{
		public readonly MutableFilmLensDbContext MutableDbContext;
		public readonly ReadonlyFilmLensDbContext ReadOnlyDbContext;

		/// <inheritdoc/>
		public EfRepositoryBase(
			MutableFilmLensDbContext mutableDbContext,
			ReadonlyFilmLensDbContext readOnlyDbContext)
		{
			MutableDbContext = mutableDbContext;
			ReadOnlyDbContext = readOnlyDbContext;
		}

		/// <inheritdoc/>
		public async Task AddAsync(T entity, CancellationToken cancellation)
		{
			await MutableDbContext.AddAsync(entity, cancellation);
			await MutableDbContext.SaveChangesAsync(cancellation);
		}

		/// <inheritdoc/>
		public virtual Task<List<T>> GetAllAsync(CancellationToken cancellation)
		{
			return ReadOnlyDbContext.Set<T>().ToListAsync(cancellation);
		}

		/// <inheritdoc/>
		public virtual Task<T> GetAsync(int id)
		{
			return MutableDbContext.FindAsync<T>(id).AsTask();
		}

		/// <inheritdoc/>
		public Task UpdateAsync(T entity, CancellationToken cancellation)
		{
			MutableDbContext.Update(entity);
			return MutableDbContext.SaveChangesAsync(cancellation);
		}
	}
}
