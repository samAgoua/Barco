using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot add different currencies");

            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot subtract different currencies");

            return new Money(left.Amount - right.Amount, left.Currency);
        }

        public static bool operator <(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot compare different currencies");

            return left.Amount < right.Amount;
        }

        public static bool operator >(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Cannot compare different currencies");

            return left.Amount > right.Amount;
        }
    }
}
