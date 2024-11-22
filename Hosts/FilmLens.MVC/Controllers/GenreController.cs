using FilmLens.AppServices.Genres.Repositories;
using FilmLens.AppServices.Genres.Services;
using FilmLens.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmLens.MVC.Controllers
{
	public class GenreController : Controller
	{
		private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

		public async Task<IActionResult> GenresPage(CancellationToken cancellationToken)
		{
			var genres = await _genreRepository.GetAllGenresAsync(cancellationToken);

			var viewModel = new MovieGenreViewModel
			{ 
				Genres = genres 
			};
			return View(viewModel);
		}
	}
}
