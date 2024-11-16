using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Domain.Common
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents = new ();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
