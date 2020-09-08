using System;
using System.Collections.Generic;
using System.Text;
using CleanBank.Core.Accounts;
using CleanBank.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanBank.Tests.Core
{
    [TestClass]
    public class HomeEquityAccountTests
    {
        [TestMethod]
        public void Open()
        {
            var account = new HomeEquity();
            account.Withdraw(45);
            Assert.AreEqual(account.Inquiry(), -45);
        }

        [TestMethod]
        public void Inquiry()
        {
            var account = new HomeEquity(new TransactionsBuilder()
                .Deposit(123)
                .Build());
            Assert.AreEqual(123, account.Inquiry());
            account = new HomeEquity(new TransactionsBuilder()
                .Deposit(456)
                .Build());
            Assert.AreEqual(456, account.Inquiry());
        }

        [TestMethod]
        public void CanUseDecimalInBalance()
        {
            var init = new TransactionsBuilder()
                .Deposit(123.65)
                .Build();
            var account = new HomeEquity(init);
            Assert.AreEqual(123.65, account.Inquiry());
        }

        [TestMethod]
        public void Withdraw()
        {
            var init = new TransactionsBuilder()
                .Deposit(3124)
                .Build();
            var account = new HomeEquity(init);
            account.Withdraw(56);
            Assert.AreEqual(3068, account.Inquiry());
        }

        [TestMethod]
        public void Deposit()
        {
            var init = new TransactionsBuilder()
                .Deposit(868)
                .Build();
            var account = new HomeEquity(init);
            account.Deposit(68);
            Assert.AreEqual(936, account.Inquiry());
        }

        [TestMethod]
        [ExpectedException(typeof(DepositLimitException))]
        public void DepositOverLimit()
        {
            var init = new TransactionsBuilder()
                .Deposit(600)
                .Build();
            var account = new HomeEquity(init);
            account.Deposit(700);
        }
    }
}
