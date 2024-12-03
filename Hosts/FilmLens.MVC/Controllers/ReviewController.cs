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
        private readonly IUserService _userService;

        public ReviewController(IReviewService reviewService, IUserService userService)
        {
            _reviewService = reviewService;
            _userService = userService;
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
    }
}
