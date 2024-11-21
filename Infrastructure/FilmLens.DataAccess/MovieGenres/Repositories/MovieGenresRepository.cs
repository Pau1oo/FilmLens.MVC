using FilmLens.AppServices.MovieGenres.Repositories;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.MovieGenres.Repositories
{
	public sealed class MovieGenresRepository : EfRepositoryBase<MovieGenre>, IMovieGenresRepository
	{
		public MovieGenresRepository(
			MutableFilmLensDbContext mutableDbContext,
			ReadonlyFilmLensDbContext readOnlyDbContext)
			: base(mutableDbContext, readOnlyDbContext)
		{
		}


	}
}
