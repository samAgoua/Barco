using Barco.Librairie.Domain.Common;
using Barco.Librairie.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Infrastructure.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                var handlerType = typeof(IDomainEventHandler<>)
                    .MakeGenericType(domainEvent.GetType());

                var handlers = _serviceProvider
                    .GetServices(handlerType)
                    .Cast<dynamic>();

                foreach (var handler in handlers)
                {
                    await handler.HandleAsync((dynamic)domainEvent);
                }
            }
        }
    }
}
