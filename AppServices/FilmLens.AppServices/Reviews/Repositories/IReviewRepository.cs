using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Reviews.Repositories
{
	public interface IReviewRepository : IRepository<Review>
	{
		/// <summary>
		/// Получает список всех комментариев.
		/// </summary>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<Review>> GetAllAsync(CancellationToken cancellationToken);

		/// <summary>
		/// Получает комментарий по его идентификатору.
		/// </summary>
		/// <param name="reviewId">Идентификатор комментария.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<Review> GetReviewAsync(int reviewId, CancellationToken cancellationToken);

		/// <summary>
		/// Удаляет комментарий из базы данных.
		/// </summary>
		/// <param name="review">Сущность комментария.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task DeleteAsync(Review review, CancellationToken cancellationToken);
	}
}
