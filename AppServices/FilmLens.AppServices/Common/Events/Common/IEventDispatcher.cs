using FilmLens.Domain.Events;

namespace FilmLens.AppServices.Common.Events.Common
{
    /// <summary>
    /// Интерфейс диспатчера доменных событий.
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Выполняет обработку доменного события.
        /// </summary>
        /// <param name="domainEvent">Доменное событие.</param>
        Task DispatchAsync(IDomainEvent domainEvent);
    }
}
