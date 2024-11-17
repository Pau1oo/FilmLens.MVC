using FilmLens.AppServices.Movies.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.Movies.Repositories
{
	public sealed class MovieRepository : EfRepositoryBase<Movie>, IMovieRepository
	{
        public MovieRepository(
            MutableFilmLensDbContext mutableDbContext,
            ReadonlyFilmLensDbContext readOnlyDbContext)
            : base(mutableDbContext, readOnlyDbContext)
        { 
        }
    }
}
