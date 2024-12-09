using FilmLens.Contracts.Reviews;

namespace FilmLens.AppServices.Reviews.Services
{
	/// <summary>
	/// Интерфейс сервиса по работе с комментариями.
	/// </summary>
	public interface IReviewService
	{
		/// <summary>
		/// Добавляет комментарий в базу данных.
		/// </summary>
		/// <param name="reviewDto">Транспортная модель комментария.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task AddReviewAsync(ReviewDto reviewDto, CancellationToken cancellationToken);

		/// <summary>
		/// Получает список комментариев, написанных к фильму.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<ReviewDto>> GetMovieReviewsAsync(int movieId, CancellationToken cancellationToken);

		/// <summary>
		/// Получает список комментариев, написанных пользователем.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		Task<List<ReviewDto>> GetUserReviewsAsync(int userId, CancellationToken cancellationToken);
	}
}
