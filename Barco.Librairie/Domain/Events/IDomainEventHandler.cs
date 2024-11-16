using Barco.Librairie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Domain.Events
{
    public interface IDomainEventHandler<in TEvent>
       where TEvent : IDomainEvent
    {
        Task HandleAsync(TEvent domainEvent);
    }
}
