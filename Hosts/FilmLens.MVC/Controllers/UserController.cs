using FilmLens.AppServices.Users.Services;
using FilmLens.Domain.Entities;
using FilmLens.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmLens.MVC.Controllers
{
	public class UserController : Controller
	{
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userService.GetUserAsync(User);

            var userProfile = new UserProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                ReviewCount = user.ReviewCount
            };

            return View("Profile", userProfile);
        }
    }
}
