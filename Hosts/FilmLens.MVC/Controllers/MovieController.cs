using AutoMapper;
using FilmLens.AppServices.Common.TMDb;
using FilmLens.AppServices.Movies.Services;
using FilmLens.Contracts.Common;
using FilmLens.Contracts.Movies;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLens.MVC.Controllers
{
	public class MovieController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly ITmdbService _tmdbService;
		private readonly IMapper _mapper;

		public MovieController(IMovieService movieService, ITmdbService tmdbService, IMapper mapper)
        {
            _movieService = movieService;
            _tmdbService = tmdbService;
			_mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
			var cancellationToken = HttpContext.RequestAborted;

			var existingMovie = await _movieService.GetMoviesAsync(new PagedRequest
            { PageNumber = 1, PageSize = int.MaxValue }, cancellationToken);

			if (existingMovie.Result.Any(m => m.TmdbId == model.TmdbId.ToString()))
			{
				return Json(new { success = false, message = "Фильм с таким ID уже существует в базе данных." });
			}

			var tmdbMovie = await _tmdbService.GetMovieDetails(model.TmdbId);

			if (tmdbMovie == null)
			{
				ModelState.AddModelError(string.Empty, "Фильм с таким ID не найден в TMDb API.");
				return Json(new { success = false, message = "Фильм не найден!" });
			}

			var movieDto = _mapper.Map<MovieDto>(tmdbMovie);

			await _movieService.AddMovieAsync(movieDto, cancellationToken);

			TempData["SuccessMessage"] = "Фильм успешно добавлен!";
			return RedirectToAction("Index", "Home");
		}

		public IActionResult AddMovie()
		{
			var model = new AddMovieViewModel();
			return View(model);
		}
	}
}
