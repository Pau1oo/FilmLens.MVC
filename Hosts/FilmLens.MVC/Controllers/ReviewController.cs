using FilmLens.AppServices.Reviews.Repositories;
using FilmLens.AppServices.Reviews.Services;
using FilmLens.AppServices.Users.Services;
using FilmLens.Contracts.Reviews;
using FilmLens.Domain.Entities;
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

		public async Task<IActionResult> RemoveReview(int reviewId, string returnUrl, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetReviewAsync(reviewId, cancellationToken);

			await _reviewRepository.DeleteAsync(review, cancellationToken);

			return Redirect(returnUrl);
		}
	}
}
