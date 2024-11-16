using Barco.Librairie.Domain.ValueObjects;
using Barco.Librairie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FluentResults;
using Barco.Librairie.Domain.Common;
using Barco.Librairie.Domain.Events;

namespace Barco.Librairie.Domain.AggregateRoots
{
    public class Account : Entity
    {
        #region Properties
        public AccountId Id { get; private set; }
        public CustomerId OwnerId { get; private set; }
        public Money Balance { get; private set; }
        public AccountStatus Status { get; private set; }

        private List<Entities.Transaction> _transactions;
        #endregion

        #region Constructors
        public Account(CustomerId ownerId, Money initialDeposit)
        {
            Id = new AccountId(Guid.NewGuid());
            OwnerId = ownerId;
            Balance = initialDeposit;
            Status = AccountStatus.Active;
            _transactions = new List<Entities.Transaction>();

            AddDomainEvent(new AccountOpened(Id, ownerId, initialDeposit));
        
        }
        #endregion

        #region Methods

        public static Account Create(CustomerId ownerId, Money initialDeposit)
        {
            return new Account(ownerId, initialDeposit);
        }
        public Result<Entities.Transaction> Deposit(Money amount)
        {
            if (Status != AccountStatus.Active)
                return Result.Fail<Entities.Transaction>("Account is not active");

            var transaction = new Entities.Transaction(
                new TransactionId(Guid.NewGuid()),
                Id,
                TransactionType.Credit,
                amount,
                DateTime.UtcNow
            );

            Balance += amount;
            _transactions.Add(transaction);

            AddDomainEvent(new MoneyDeposited(Id, amount, Balance));

            return Result.Ok(transaction);
        }

        public Result<Entities.Transaction> Withdraw(Money amount)
        {
            if (Status != AccountStatus.Active)
                return Result.Fail<Entities.Transaction>("Account is not active");

            if (Balance < amount)
                return Result.Fail<Entities.Transaction>("Insufficient funds");

            var transaction = new Entities.Transaction(
                new TransactionId(Guid.NewGuid()),
                Id,
                TransactionType.Debit,
                amount,
                DateTime.UtcNow
            );

            Balance -= amount;
            _transactions.Add(transaction);

            AddDomainEvent(new MoneyWithdrawn(Id, amount, Balance));

            return Result.Ok(transaction);
        }
        #endregion
    }
}
