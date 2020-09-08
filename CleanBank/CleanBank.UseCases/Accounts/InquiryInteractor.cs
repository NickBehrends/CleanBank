using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanBank.Core.Accounts;
using CleanBank.Core.Transactions;

namespace CleanBank.UseCases.Accounts
{
    public class InquiryInteractor
    {
        private readonly ITransactionRepository _transactionRepository;

        public InquiryInteractor(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<double> Inquire(Guid userId, AccountType accountType)
        {
            var transactions = await _transactionRepository.GetUsersTransactions(userId);

            var account = new AccountFactory().GetAccount(accountType, transactions);
            return account.Inquiry();
        }
    }
}
