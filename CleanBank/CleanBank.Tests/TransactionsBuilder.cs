using System;
using System.Collections.Generic;
using System.Text;
using CleanBank.Core.Transactions;

namespace CleanBank.Tests
{
    public class TransactionsBuilder
    {
        private readonly ICollection<ITransaction> _transactions;

        public TransactionsBuilder()
        {
            _transactions = new List<ITransaction>();
        }

        public TransactionsBuilder Deposit(double amount)
        {
            _transactions.Add(new DepositTransaction(amount));
            return this;
        }

        public ICollection<ITransaction> Build()
        {
            return _transactions;
        }
    }
}
