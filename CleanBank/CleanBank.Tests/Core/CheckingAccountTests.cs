using System;
using System.Collections.Generic;
using System.Text;
using CleanBank.Core.Accounts;
using CleanBank.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanBank.Tests.Core
{
    [TestClass]
    public class CheckingAccountTests
    {
        [TestMethod]
        public void Deposit()
        {
            var init = new TransactionsBuilder()
                .Deposit(234)
                .Build();
            var account = new Checking(init);
            account.Deposit(65);
            Assert.AreEqual(account.Inquiry(), 299);
        }

        [TestMethod]
        public void Inquiry()
        {
            var account = new Checking(new TransactionsBuilder()
                .Deposit(123)
                .Build());
            Assert.AreEqual(account.Inquiry(), 123);

            account = new Checking(new TransactionsBuilder()
                .Deposit(456)
                .Build());
            Assert.AreEqual(account.Inquiry(), 456);
        }

        [TestMethod]
        public void CanUseDecimalInBalance()
        {
            var init = new TransactionsBuilder()
                .Deposit(123.65)
                .Build();
            var account = new Checking(init);
            Assert.AreEqual(123.65, account.Inquiry());
        }

        [TestMethod]
        public void Withdraw()
        {
            var init = new TransactionsBuilder()
                .Deposit(587)
                .Build();
            var account = new Checking(init);
            account.Withdraw(460);
            Assert.AreEqual(account.Inquiry(), 127);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void OverWithdraw()
        {
            var init = new TransactionsBuilder()
                .Deposit(40)
                .Build();
            var account = new Checking(init);
            account.Withdraw(50);
        }
    }
}
