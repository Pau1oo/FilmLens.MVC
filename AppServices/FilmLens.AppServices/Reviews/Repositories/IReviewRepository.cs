using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Reviews.Repositories
{
	public interface IReviewRepository : IRepository<Review>
	{
		Task<List<Review>> GetAllAsync(CancellationToken cancellation);

		Task<Review> GetReviewAsync(int reviewId, CancellationToken cancellationToken);

		Task DeleteAsync(Review review, CancellationToken cancellationToken);
	}
}
