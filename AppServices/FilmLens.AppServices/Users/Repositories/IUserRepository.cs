using FilmLens.AppServices.Common;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Users.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> userIds, CancellationToken cancellationToken);
	}
}
