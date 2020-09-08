using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBank.Core.Transactions
{
    public class WithdrawTransaction : ITransaction
    {
        public WithdrawTransaction(double amount)
        {
            Amount = amount;
        }

        public DateTime DateOccured { get; } = DateTime.UtcNow;
        public TransactionType Type { get; } = TransactionType.Withdraw;
        public double? Amount { get; }
    }
}
