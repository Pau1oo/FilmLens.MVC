using FilmLens.Contracts.Reviews;

namespace FilmLens.AppServices.Reviews.Services
{
	public interface IReviewService
	{
		Task AddReviewAsync(ReviewDto reviewDto, CancellationToken cancellationToken);

		Task<List<ReviewDto>> GetMovieReviewsAsync(int movieId, CancellationToken cancellationToken);

		Task<List<ReviewDto>> GetUserReviewsAsync(int userId, CancellationToken cancellationToken);
	}
}
