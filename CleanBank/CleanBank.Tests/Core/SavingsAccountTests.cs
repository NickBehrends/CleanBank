using System;
using System.Collections.Generic;
using System.Text;
using CleanBank.Core.Accounts;
using CleanBank.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanBank.Tests.Core
{
    [TestClass]
    public class SavingsAccountTests
    {
        [TestMethod]
        public void Inquiry()
        {
            var transactions = new TransactionsBuilder()
                .Deposit(65.98)
                .Deposit(76.43)
                .Build();

            var account = new Savings(transactions);
            Assert.AreEqual(65.98 + 76.43, account.Inquiry());
        }

        [TestMethod]
        public void Deposit()
        {
            var init = new TransactionsBuilder()
                .Deposit(876)
                .Build();
            var account = new Savings(init);

            account.Deposit(56);
            Assert.AreEqual(account.Inquiry(), 932);
        }

        [TestMethod]
        public void Withdraw()
        {
            var init = new TransactionsBuilder()
                .Deposit(509)
                .Build();
            var account = new Savings(init);

            account.Withdraw(65);
            Assert.AreEqual(444, account.Inquiry());
        }

        [TestMethod]
        public void DepositAndWithdraw()
        {
            var init = new TransactionsBuilder()
                .Deposit(689)
                .Build();
            var account = new Savings(init);

            account.Withdraw(59);
            Assert.AreEqual(630, account.Inquiry());

            account.Deposit(503);
            Assert.AreEqual(1133, account.Inquiry());

            account.Withdraw(367);
            Assert.AreEqual(766, account.Inquiry());
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void OverWithdraw()
        {
            var init = new TransactionsBuilder()
                .Deposit(40)
                .Build();
            var account = new Savings(init);
            account.Withdraw(50);
        }

        [TestMethod]
        [ExpectedException(typeof(WithdrawLimitException))]
        public void WithdrawOverLimit()
        {
            var init = new TransactionsBuilder()
                .Deposit(580)
                .Build();
            var account = new Savings(init);
            account.Withdraw(501);
        }

        [TestMethod]
        [ExpectedException(typeof(WithdrawTimeLimitException))]
        public void WithdrawOverLimitOver24Hours()
        {
            var init = new TransactionsBuilder()
                .Deposit(509)
                .Build();
            var account = new Savings(init);

            account.Withdraw(100);
            account.Withdraw(100);
            account.Withdraw(100);
            account.Withdraw(100);
            account.Withdraw(100);
            account.Withdraw(8);
        }
    }
}
