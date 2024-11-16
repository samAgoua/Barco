using Barco.Librairie.Domain.Common;
using Barco.Librairie.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Domain.Events
{
    public record MoneyWithdrawn : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
        public AccountId AccountId { get; }
        public Money Amount { get; }
        public Money NewBalance { get; }

        public MoneyWithdrawn(AccountId accountId, Money amount, Money newBalance)
        {
            AccountId = accountId;
            Amount = amount;
            NewBalance = newBalance;
        }
    }
}
