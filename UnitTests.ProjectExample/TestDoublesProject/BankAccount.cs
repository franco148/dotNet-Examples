using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDoublesProject
{
    public interface ILog
    {
        void Write(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILog log;


        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            log.Write($"Depositing {amount}");
            Balance += amount;
        }
    }


    public class NullLog : ILog
    {
        public void Write(string msg)
        {
            
        }
    }

    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount ba;

        /**
         * Because using ConsoleLog, this is an integration test.
         */
        [Test]
        public void DepositIntegrationTest()
        {
            ba = new BankAccount(new ConsoleLog()) { Balance = 100 };
            ba.Deposit(100);

            Assert.That(ba.Balance, Is.EqualTo(200));
        }

        [Test]
        public void DepositUnitTestWithFake()
        {
            var log = new NullLog();
            ba = new BankAccount(log) { Balance = 100 };
            ba.Deposit(100);
            
            Assert.That(ba.Balance, Is.EqualTo(200));
        }
    }
}
