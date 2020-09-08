using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBank.Core.Transactions
{
    public class DepositTransaction : ITransaction
    {
        public DepositTransaction(double amount)
        {
            Amount = amount;
        }

        public DateTime DateOccured { get; } = DateTime.UtcNow;
        public TransactionType Type { get; } = TransactionType.Deposit;
        public double? Amount { get; }
    }
}
