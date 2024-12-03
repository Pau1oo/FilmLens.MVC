using FilmLens.AppServices.Common;
using FilmLens.AppServices.Movies.Models;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Movies.Repositories
{
	public interface IMovieRepository : IRepository<Movie>
	{
		Task<List<Movie>> GetMoviesAsync(GetMoviesRequest request, CancellationToken cancellation);

		Task<int> GetMoviesTotalCountAsync(int? genreId, CancellationToken cancellation);

		Task<Movie> GetMovieAsync(int movieId, CancellationToken cancellationToken);

		Task<List<Movie>> GetMoviesByIdsAsync(IEnumerable<int> movieIds, CancellationToken cancellationToken);
	}
}
