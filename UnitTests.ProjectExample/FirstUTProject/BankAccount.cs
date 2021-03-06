﻿using NUnit.Framework;
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
            if (amount <= 0)
                throw new ArgumentException("Deposit amout must be positive", nameof(amount));
            
            Balance += amount;
        }

        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    [TestFixture]
    public class DataDrivenTests
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }

        //Data-Driven Testing.
        [Test]
        [TestCase(50, true, 50)]
        [TestCase(100, true, 0)]
        [TestCase(1000, false, 100)]
        public void TestMultipleWithdrawaScenarios(int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.Withdraw(amountToWithdraw);
            //Warn.If(!result, "Failed for some reason");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(shouldSucceed));

                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
            });
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

        [Test]
        public void BankAccountShouldThrownOnNonPositiveAmount()
        {
            //Instead of this, we can implement this as lambda expression.
            //ba.Deposit(-100);

            var ex = Assert.Throws<ArgumentException>(() => ba.Deposit(-100));

            //Typically a unit test should have only a assertion, but some cases we
            //would need to verify something else. For example.
            StringAssert.StartsWith("Deposit amout must be positive", ex.Message);
        }

    }
}
