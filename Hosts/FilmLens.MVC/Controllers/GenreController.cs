using FilmLens.AppServices.Genres.Repositories;
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

		/// <summary>
		/// Заполняет данными страницу с жанрами.
		/// </summary>
		/// <param name="cancellationToken">Токен отмены операции.</param>
		public async Task<IActionResult> GenresPage(CancellationToken cancellationToken)
		{
			var genres = await _genreRepository.GetAllGenresAsync(cancellationToken);

			var viewModel = new GenresViewModel
			{ 
				Genres = genres 
			};
			return View(viewModel);
		}
	}
}
