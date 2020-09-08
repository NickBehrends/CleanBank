using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBank.Core.Transactions
{
    public interface ITransaction
    {
        DateTime DateOccured { get; }
        TransactionType Type { get; }
        double? Amount { get; }
    }
}
