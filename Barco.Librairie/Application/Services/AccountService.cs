using Barco.Librairie.Domain.AggregateRoots;
using Barco.Librairie.Domain.Entities;
using Barco.Librairie.Domain.ValueObjects;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Application.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AccountId>> OpenAccountAsync(
            CustomerId ownerId,
            Money initialDeposit)
        {
            var account = new Account(ownerId, initialDeposit);
            await _accountRepository.AddAsync(account);
            await _unitOfWork.SaveChangesAsync();

            return Result.Ok(account.Id);
        }

        public async Task<Result<Transaction>> DepositAsync(
            AccountId accountId,
            Money amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
                return Result.Fail<Transaction>("Account not found");

            var result = account.Deposit(amount);
            if (result.IsSuccess)
                await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
