using FilmLens.AppServices.Genres.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.Genres.Repositories
{
	public sealed class GenreRepository : EfRepositoryBase<Genre>, IGenreRepository
	{
        public GenreRepository(
            MutableFilmLensDbContext mutableDbContext,
            ReadonlyFilmLensDbContext readOnlyDbContext)
            : base(mutableDbContext, readOnlyDbContext)
        {
        }
    }
}
