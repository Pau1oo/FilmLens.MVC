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
		public Task AddAsync(T entity)
		{
			return MutableDbContext.AddAsync(entity).AsTask();
		}

		/// <inheritdoc/>
		public virtual Task<List<T>> GetAllAsync()
		{
			return ReadOnlyDbContext.Set<T>().ToListAsync();
		}

		/// <inheritdoc/>
		public virtual Task<T> GetAsync(int id)
		{
			return MutableDbContext.FindAsync<T>(id).AsTask();
		}
	}
}
