using FilmLens.AppServices.Reviews.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.Reviews.Repositories
{
	public sealed class ReviewRepository : EfRepositoryBase<Review>, IReviewRepository
	{
		public ReviewRepository(
			MutableFilmLensDbContext mutableDbContext,
			ReadonlyFilmLensDbContext readOnlyDbContext)
			: base(mutableDbContext, readOnlyDbContext)
		{
		}

		public async override Task<List<Review>> GetAllAsync(CancellationToken cancellation)
		{
			return await ReadOnlyDbContext.Set<Review>()
				.ToListAsync(cancellation);
		}
	}
}
