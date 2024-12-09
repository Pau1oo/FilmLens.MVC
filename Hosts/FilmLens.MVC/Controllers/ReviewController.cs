using FilmLens.AppServices.Reviews.Repositories;
using FilmLens.AppServices.Reviews.Services;
using FilmLens.Contracts.Reviews;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLens.MVC.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IReviewService _reviewService;
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewService reviewService,
                                IReviewRepository reviewRepository)
        {
            _reviewService = reviewService;
            _reviewRepository = reviewRepository;
        }

        /// <summary>
        /// Создает комментарий.
        /// </summary>
        /// <param name="model">Данные о комментарии.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<IActionResult> AddReview(MovieViewModel model, CancellationToken cancellationToken)
        {
            var reviewDto = new ReviewDto
            {
                ReviewText = model.Review.ReviewText,
                ReviewerUserId = model.Review.ReviewerUserId,
                ReviewedMovieId = model.Review.ReviewedMovieId,
                CreatedAt = DateTime.UtcNow.AddHours(3)
            };

            await _reviewService.AddReviewAsync(reviewDto, cancellationToken);

            return RedirectToAction("MoviePage", "Movie", new { id = model.Review.ReviewedMovieId });
        }

        /// <summary>
        /// Удаляет комментарий.
        /// </summary>
        /// <param name="reviewId">Идентификатор комментария.</param>
        /// <param name="returnUrl">Путь к странице.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> RemoveReview(int reviewId, string returnUrl, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetReviewAsync(reviewId, cancellationToken);

			if (review == null)
			{
				TempData["ModalMessage"] = "Комментарий с указанным ID не найден.";
				return Redirect(returnUrl);
			}

			await _reviewRepository.DeleteAsync(review, cancellationToken);

			TempData["SuccessMessage"] = "Комментарий успешно удален.";
			return Redirect(returnUrl);
		}
	}
}
