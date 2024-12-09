using FilmLens.AppServices.Reviews.Services;
using FilmLens.AppServices.Users.Services;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLens.MVC.Controllers
{
	public class UserController : Controller
	{
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;
        public UserController(IUserService userService,
                              IReviewService reviewService)
        {
            _userService = userService;
            _reviewService = reviewService;
        }

        /// <summary>
        /// Заполняет данными профиль пользователя.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        public async Task<IActionResult> Profile(CancellationToken cancellationToken)
        {

            var user = await _userService.GetUserAsync(User);
            var reviews = await _reviewService.GetUserReviewsAsync(user.Id, cancellationToken);

            var userProfile = new UserProfileViewModel
            {
                Role = User.IsInRole("Admin") ? "Администратор" :
                       User.IsInRole("User") ? "Пользователь": "Неизвестно",
                UserId = user.Id,
				UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                ReviewCount = reviews.Count,
                Reviews = reviews
            };

            return View("Profile", userProfile);
        }
    }
}
