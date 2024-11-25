using FilmLens.Contracts.Genres;
using FilmLens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLens.AppServices.Genres.Services
{
	/// <summary>
	/// Интерфейс сервиса по работе с жанрами.
	/// </summary>
	public interface IGenreService
	{
		Task<List<GenreDto>> GetGenresAsync(int movieId, CancellationToken cancellation);
	}
}
