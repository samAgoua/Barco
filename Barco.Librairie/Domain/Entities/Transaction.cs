using Barco.Librairie.Domain.AggregateRoots;
using Barco.Librairie.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Barco.Librairie.Domain.Entities
{
    public class Transaction
    {
        public TransactionId Id { get; }
        public AccountId AccountId { get; }
        public TransactionType Type { get; }
        public Money Amount { get; }
        public DateTime Timestamp { get; }

        public Transaction(
            TransactionId id,
            AccountId accountId,
            TransactionType type,
            Money amount,
            DateTime timestamp)
        {
            Id = id;
            AccountId = accountId;
            Type = type;
            Amount = amount;
            Timestamp = timestamp;
        }
    }
}
