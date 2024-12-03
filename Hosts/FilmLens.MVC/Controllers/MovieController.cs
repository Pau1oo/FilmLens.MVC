using AutoMapper;
using FilmLens.AppServices.Common.TMDb;
using FilmLens.AppServices.Genres.Services;
using FilmLens.AppServices.Movies.Services;
using FilmLens.AppServices.Reviews.Services;
using FilmLens.AppServices.Users.Services;
using FilmLens.Contracts.Common;
using FilmLens.Contracts.Movies;
using FilmLens.Domain.Entities;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace FilmLens.MVC.Controllers
{
	public class MovieController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly IGenreService _genreService;
		private readonly IReviewService _reviewService;
		private readonly ITmdbService _tmdbService;
		private readonly IMapper _mapper;

		public MovieController(IMovieService movieService, 
							   IGenreService genreService,
							   IReviewService reviewService,
							   ITmdbService tmdbService, 
							   IMapper mapper)
        {
            _movieService = movieService;
			_genreService = genreService;
			_reviewService = reviewService;
            _tmdbService = tmdbService;
			_mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(CommonViewModel model, CancellationToken cancellationToken)
        {
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

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> MoviesPage(int pageNumber = 1, int? genreId = null, string? genreName = null, CancellationToken cancellationToken = default)
		{
			var result = await _movieService.GetMoviesAsync(new PagedRequest
			{ 
				PageNumber = pageNumber,
				PageSize = 15, 
				GenreId = genreId,
				GenreName = genreName
			}, cancellationToken);

			return View(result);
		}

		public async Task<IActionResult> MoviePage(int id, CancellationToken cancellationToken)
		{
			var movie = await _movieService.GetMovieAsync(id, cancellationToken);
			var genres = await _genreService.GetGenresAsync(id, cancellationToken);
			var reviews = await _reviewService.GetMovieReviewsAsync(id, cancellationToken);

			var result = new MovieViewModel 
			{
				Movie = movie,
				Genres = genres,
				Reviews = reviews
			};

			return View(result);
		}
	}
}
