using System;
using System.Collections.Generic;
using System.Text;
using CleanBank.Core.Accounts;
using CleanBank.Core.Transactions;

namespace CleanBank.UseCases.Accounts
{
    public class AccountFactory
    {
        public Account GetAccount(AccountType accountType, ICollection<ITransaction> transactions)
        {
            switch (accountType)
            {
                case AccountType.Saving:
                    return new Savings(transactions);
                case AccountType.Checking:
                    return new Checking(transactions);
                case AccountType.HomeEquity:
                    return new HomeEquity(transactions);
                default:
                    throw new IndexOutOfRangeException("Account type is not recognized.");
            }
        }
    }
}
