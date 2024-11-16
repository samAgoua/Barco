using Barco.Librairie.Domain.Common;
using Barco.Librairie.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Domain.Events
{
    public record AccountOpened : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
        public AccountId AccountId { get; }
        public CustomerId CustomerId { get; }
        public Money InitialBalance { get; }

        public AccountOpened(AccountId accountId, CustomerId customerId, Money initialBalance)
        {
            AccountId = accountId;
            CustomerId = customerId;
            InitialBalance = initialBalance;
        }
    }
}
