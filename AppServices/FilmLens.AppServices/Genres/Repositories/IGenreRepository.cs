using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Genres.Repositories
{
	public interface IGenreRepository : IRepository<Genre>
	{
		Task<List<Genre>> GetGenresByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);

		Task<List<Genre>> GetAllGenresAsync(CancellationToken cancellationToken);

		Task<List<Genre>> GetGenresByMovieIdAsync(int movieId, CancellationToken cancellationToken);
	}
}
