using FilmLens.AppServices.Authentication.Services;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLens.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

		/// <summary>
		/// Осуществляет регистрацию пользователя.
		/// </summary>
		/// <param name="model">Модель с данными для регистрации.</param>
		/// <param name="cancellation">Токен отменыф операции.</param>
		[HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, CancellationToken cancellation)
        {
            var result = await _authService.RegisterAsync(model.Name, model.Email, model.Password, cancellation);
            if (result.Succeeded)
            {
				await _authService.SignInAsync(model.Email, model.Password, cancellation);
				return RedirectToAction("Index", "Home");
			}

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

		/// <summary>
		/// Осуществляет авторизацию и аутентификацию пользователя.
		/// </summary>
		/// <param name="model">Данные для входа.</param>
		/// <param name="cancellation">Токен отмены операции.</param>
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model, CancellationToken cancellation)
		{
			if (await _authService.SignInAsync(model.Email, model.Password, cancellation))
			{
				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View();
		}

		/// <summary>
		/// Разлогинивает пользователя.
		/// </summary>
		/// <param name="cancellation">Токен отмены операции.</param>
		public async Task<IActionResult> Logout(CancellationToken cancellation)
		{
			await _authService.SignOutAsync(cancellation);
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Login()
		{
			var model = new LoginViewModel();
			return View(model);
		}
	}
}
