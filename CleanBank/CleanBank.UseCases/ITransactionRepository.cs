using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanBank.Core.Transactions;

namespace CleanBank.UseCases
{
    public interface ITransactionRepository
    {
        Task<ICollection<ITransaction>> GetUsersTransactions(Guid userId);
        Task Deposit(Guid userId, double amount);
        Task Withdraw(Guid userId, double amount);
    }
}
