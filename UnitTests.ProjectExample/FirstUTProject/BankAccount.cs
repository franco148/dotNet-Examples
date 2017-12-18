using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUTProject
{
    class BankAccount
    {
        public int Balance { get; private set; }

        public BankAccount(int startingBalance)
        {
            Balance = startingBalance;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {

        }
    }

    [TestFixture]
    public class BankAccountTests
    {

        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }

        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            // AAA: Arrange, Act and Assert.

            // Arrange
            //var ba = new BankAccount(100);

            // Act
            ba.Deposit(100);

            // Assert
            Assert.That(ba.Balance, Is.EqualTo(200));
        }

        [Test]
        public void WarningUnitTest001()
        {
            Warn.If(2 + 2 != 5);
            Warn.If(2+2, Is.Not.EqualTo(5));
            Warn.If(()=> 2+2, Is.Not.EqualTo(5).After(2000));

            Warn.Unless(2+2 == 5);
            Warn.Unless(2+2, Is.EqualTo(5));
            Warn.Unless(() => 2+2, Is.EqualTo(5).After(3000));

            Assert.Warn("I'm warning you");
        }

        [Test]
        public void MultipleAssertionUnitTest002()
        {
            ba.Withdraw(100);

            //Assert.That(ba.Balance, Is.EqualTo(0));
            //Assert.That(ba.Balance, Is.LessThan(1));

            Assert.Multiple(() =>
            {
                Assert.That(ba.Balance, Is.EqualTo(0));
                Assert.That(ba.Balance, Is.LessThan(1));
            });
        }

    }
}
