using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CleanBank.Core.Exceptions;
using CleanBank.Core.Transactions;

namespace CleanBank.Core.Accounts
{
    public class HomeEquity : Account
    {
        public HomeEquity() : base()
        {
        }

        public HomeEquity(ICollection<ITransaction> transactions) : base(transactions)
        {
        }

        public override void Deposit(double amount)
        {
            if (amount > Inquiry())
                throw new DepositLimitException("While we would love to take all your money, you do not owe us that much");

            Transactions.Add(new DepositTransaction(amount));
        }
    }
}
