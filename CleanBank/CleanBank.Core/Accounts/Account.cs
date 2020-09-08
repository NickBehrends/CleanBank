using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CleanBank.Core.Transactions;

namespace CleanBank.Core.Accounts
{
    public abstract class Account
    {
        protected ICollection<ITransaction> Transactions { get; }

        protected Account()
        {
            Transactions = new Collection<ITransaction>();
        }

        protected Account(ICollection<ITransaction> transactions)
        {
            Transactions = transactions;
        }

        public double Inquiry()
        {
            var withdraws = Transactions
                .Where(x => x.Type == TransactionType.Withdraw)
                .Sum(x => x.Amount) ?? 0;

            var deposits = Transactions
                .Where(x => x.Type == TransactionType.Deposit)
                .Sum(x => x.Amount) ?? 0;

            return deposits - withdraws;
        }

        public virtual void Deposit(double amount)
        {
            Transactions.Add(new DepositTransaction(amount));
        }

        public virtual void Withdraw(int amount)
        {
            Transactions.Add(new WithdrawTransaction(amount));
        }
    }
}
