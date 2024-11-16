using Barco.Librairie.Domain.Events;

namespace Barco.Librairie.Application.Events
{
    internal class MoneyDepositedHandler : IDomainEventHandler<MoneyDeposited>
    {
        public Task HandleAsync(MoneyDeposited domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}