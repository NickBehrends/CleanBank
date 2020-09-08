using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CleanBank.Core.Exceptions;
using CleanBank.Core.Transactions;

namespace CleanBank.Core.Accounts
{
    public class Savings : Account
    {
        public Savings(ICollection<ITransaction> transactions) : base(transactions)
        {
        }

        public override void Withdraw(int amount)
        {
            if (amount > Inquiry())
                throw new InsufficientFundsException("There are not enough funds to cover this withdraw");

            if (amount > 500)
                throw new WithdrawLimitException("No more than $500 can be withdrawn at a time");

            var yesterday = DateTime.UtcNow.AddDays(-1);
            var transactionsOverTheLastDay = Transactions
                .Where(x => x.DateOccured > yesterday && x.Type == TransactionType.Withdraw)
                .Sum(x => x.Amount);
            if (transactionsOverTheLastDay + amount > 500)
                throw new WithdrawTimeLimitException("No more than $500 can be withdrawn over a 24 hour period. You can withdraw up to $" + (500 - transactionsOverTheLastDay));

            Transactions.Add(new WithdrawTransaction(amount));
        }
    }
}
