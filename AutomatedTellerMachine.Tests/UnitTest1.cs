using System.Web.Mvc;
using AutomatedTellerMachine.Controllers;
using AutomatedTellerMachine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnAboutView()
        {
            var homecontroller = new HomeController();
            var result = homecontroller.Foo() as ViewResult;
            if (result != null) Assert.AreEqual("About", result.ViewName);
        }
        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homecontroller = new HomeController();
            var result = homecontroller.Contact("I like ATM Bank") as ViewResult;
            if (result != null) Assert.AreEqual("We got your message!", result.ViewBag.TheMessage);
        }
        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            var fakedb = new FakeApplicationDbContext();
            fakedb.CheckingAccounts = new FakeDbSet<CheckingAccount>();

            var checkingAccount = new CheckingAccount { Id = 4, AccountNumber = "000123TEST", Balance = 0 };
            fakedb.CheckingAccounts.Add(checkingAccount);
            fakedb.Transactions = new FakeDbSet<Transaction>();
            var transactionController = new TransactionController(fakedb);
            transactionController.Deposit(new Transaction { CheckingAccountId = 4, Amount = 25 });
            Assert.AreEqual(25, checkingAccount.Balance);
        }
    }
}