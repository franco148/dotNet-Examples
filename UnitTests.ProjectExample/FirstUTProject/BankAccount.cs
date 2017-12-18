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

        }

        public void Withdraw(int amount)
        {

        }
    }

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            
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


    }
}
