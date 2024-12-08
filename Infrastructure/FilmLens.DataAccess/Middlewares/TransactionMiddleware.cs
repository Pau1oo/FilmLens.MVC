using FilmLens.AppServices.Common.Events.Common;
using FilmLens.DataAccess.Common;
using Microsoft.AspNetCore.Http;

namespace FilmLens.DataAccess.Middlewares
{
	public sealed class TransactionMiddleware
	{
		private readonly RequestDelegate _next;

        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, MutableFilmLensDbContext dbContext, 
            IEventAccumulator eventAccumulator, IEventDispatcher eventDispatcher)
        {
            await _next(context);

            var hasChanges = dbContext.HasPendingChanges();

            if(hasChanges)
            {
                using var transaction = await dbContext.Database.BeginTransactionAsync();

				await dbContext.SaveChangesAsync();

				await transaction.CommitAsync();
            }

            var events = eventAccumulator.GetAllEvents();

            foreach(var @event in events)
            {
                await eventDispatcher.DispatchAsync(@event);
            }
        }
    }
}
