using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CleanBank.Core.Exceptions;
using CleanBank.Core.Transactions;

namespace CleanBank.Core.Accounts
{
    public class Checking : Account
    {
        public Checking(ICollection<ITransaction> transactions) : base(transactions)
        {
        }

        public override void Withdraw(int amount)
        {
            if (amount > Inquiry())
                throw new InsufficientFundsException("There are not enough funds to cover this withdraw");

            Transactions.Add(new WithdrawTransaction(amount));
        }
    }
}
