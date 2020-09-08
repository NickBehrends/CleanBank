using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanBank.UseCases.Accounts
{
    public class WithdrawInteractor
    {
        private readonly ITransactionRepository _transactionRepository;

        public WithdrawInteractor(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Withdraw(Guid userId, AccountType accountType, int amount)
        {
            var transactions = await _transactionRepository.GetUsersTransactions(userId);

            var account = new AccountFactory().GetAccount(accountType, transactions);
            account.Withdraw(amount);
        }
    }
}
