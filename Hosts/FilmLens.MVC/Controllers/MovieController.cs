using AutoMapper;
using FilmLens.AppServices.Common.TMDb;
using FilmLens.AppServices.FavoriteMovies.Repositories;
using FilmLens.AppServices.Genres.Services;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.AppServices.Movies.Services;
using FilmLens.AppServices.Reviews.Services;
using FilmLens.AppServices.Users.Services;
using FilmLens.Contracts.Common;
using FilmLens.Contracts.Movies;
using FilmLens.Domain.Entities;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLens.MVC.Controllers
{
	public class MovieController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly IUserService _userService;
		private readonly IMovieRepository _movieRepository;
		private readonly IFavoriteMovieRepository _favoriteMovieRepository;
		private readonly IGenreService _genreService;
		private readonly IReviewService _reviewService;
		private readonly ITmdbService _tmdbService;
		private readonly IMapper _mapper;

		public MovieController(IMovieService movieService,
							   IMovieRepository movieRepository,
							   IFavoriteMovieRepository favoriteMovieRepository,
							   IUserService userService,
							   IGenreService genreService,
							   IReviewService reviewService,
							   ITmdbService tmdbService, 
							   IMapper mapper)
        {
            _movieService = movieService;
			_movieRepository = movieRepository;
			_favoriteMovieRepository = favoriteMovieRepository;
			_userService = userService;
			_genreService = genreService;
			_reviewService = reviewService;
            _tmdbService = tmdbService;
			_mapper = mapper;
        }

		/// <summary>
		/// Создает фильм.
		/// </summary>
		/// <param name="TmdbId">Идентификатор фильма в TMDb.</param>
		/// <param name="returnUrl">Путь к странице.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
        [HttpPost]
        public async Task<IActionResult> AddMovie(int TmdbId, string returnUrl, CancellationToken cancellationToken)
        {
			var existingMovies = await _movieService.GetMoviesAsync(new PagedRequest
            { PageNumber = 1, PageSize = int.MaxValue }, cancellationToken);

			if (existingMovies.Result.Any(m => m.TmdbId == TmdbId.ToString()))
			{
				TempData["ModalMessage"] = "Фильм уже существует в базе данных.";
				return Redirect(returnUrl);
			}

			var tmdbMovie = await _tmdbService.GetMovieDetails(TmdbId);

			if (tmdbMovie == null)
			{
				TempData["ModalMessage"] = "Фильм с указанным ID не найден в TMDb API.";
				return Redirect(returnUrl);
			}

			var movieDto = _mapper.Map<MovieDto>(tmdbMovie);

			await _movieService.AddMovieAsync(movieDto, cancellationToken);

			TempData["SuccessMessage"] = "Фильм успешно добавлен.";
			return Redirect(returnUrl);
		}

		/// <summary>
		/// Удаляет фильм.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="returnUrl">Путь к странице.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> RemoveMovie(int movieId, string returnUrl, CancellationToken cancellationToken)
		{
			var movieDto = await _movieService.GetMovieAsync(movieId, cancellationToken);

			if (movieDto == null)
			{
				TempData["ModalMessage"] = "Фильм с указанным ID не найден.";
				return Redirect(returnUrl);
			}

			var movie = _mapper.Map<Movie>(movieDto);

			await _movieRepository.DeleteAsync(movie, cancellationToken);

			TempData["SuccessMessage"] = "Фильм успешно удален.";
			return Redirect(returnUrl);
		}

		/// <summary>
		/// Заполняет данными пагинируемую страницу с фильмами.
		/// </summary>
		/// <param name="pageNumber">Номер страницы (параметр для пагинации).</param>
		/// <param name="genreId">Идентификатор жанра.</param>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="genreName">Наименование жанра.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> MoviesPage(int pageNumber = 1, int? genreId = null, int? userId = null, string? genreName = null, CancellationToken cancellationToken = default)
		{
			var result = await _movieService.GetMoviesAsync(new PagedRequest
			{ 
				PageNumber = pageNumber,
				PageSize = 15, 
				GenreId = genreId,
				GenreName = genreName,
				UserId = userId
			}, cancellationToken);

			return View(result);
		}

		/// <summary>
		/// Заполняет данными страницу с фильмом.
		/// </summary>
		/// <param name="id">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> MoviePage(int id, CancellationToken cancellationToken)
		{
			var isFavorite = false;
			var user = await _userService.GetUserAsync(User);
			var movie = await _movieService.GetMovieAsync(id, cancellationToken);
			var genres = await _genreService.GetGenresAsync(id, cancellationToken);
			var reviews = await _reviewService.GetMovieReviewsAsync(id, cancellationToken);

			if(user != null)
			{
				isFavorite = await _favoriteMovieRepository.ExistsAsync(user.Id, movie.Id);
			}
			
			var result = new MovieViewModel 
			{
				Movie = movie,
				Genres = genres,
				Reviews = reviews,
				IsFavorite = isFavorite
			};

			return View(result);
		}

		/// <summary>
		/// Добавляет фильм в избранное.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> AddToFavorites(int movieId, CancellationToken cancellationToken)
		{
			var user = await _userService.GetUserAsync(User);

			var favoriteMovie = new FavoriteMovie
			{
				UserId = user.Id,
				MovieId = movieId
			};

			await _favoriteMovieRepository.AddAsync(favoriteMovie, cancellationToken);

			return RedirectToAction("MoviePage", new { id = movieId });
		}

		/// <summary>
		/// Удаляет фильм из избранного.
		/// </summary>
		/// <param name="movieId">Идентификатор фильма.</param>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> RemoveFromFavorites(int movieId, CancellationToken cancellationToken)
		{
			var favoriteMovie = await _favoriteMovieRepository.GetFavoriteMovieAsync(movieId, cancellationToken);

			await _favoriteMovieRepository.DeleteAsync(favoriteMovie, cancellationToken);

			return RedirectToAction("MoviePage", new { id = movieId });
		}
	}
}
