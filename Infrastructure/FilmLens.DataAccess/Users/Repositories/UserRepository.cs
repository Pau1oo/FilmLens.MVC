using FilmLens.AppServices.Users.Repositories;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmLens.DataAccess.Users.Repositories
{
	public sealed class UserRepository : EfRepositoryBase<User>, IUserRepository
	{
		public UserRepository(
			MutableFilmLensDbContext mutableDbContext,
			ReadonlyFilmLensDbContext readOnlyDbContext)
			: base(mutableDbContext, readOnlyDbContext)
		{
		}

		public async Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> userIds, CancellationToken cancellationToken)
		{
			return await ReadOnlyDbContext
				.Set<User>()
				.Where(u => userIds.Contains(u.Id))
				.ToListAsync(cancellationToken);
		}

	}
}
