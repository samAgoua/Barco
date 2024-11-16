using Barco.Librairie.Domain.Events;

namespace Barco.Librairie.Application.Events
{
    internal class MoneyWithdrawnHandler: IDomainEventHandler<MoneyWithdrawn>
    {
        public Task HandleAsync(MoneyWithdrawn domainEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}