using Bank.Domain.Models;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expected).Within(0.001), 
                "Account not debited correctly");
        }

        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(expected).Within(0.001),
                "Account not credited correctly");
        }

        [Test]
        public void Credit_WithNegativeAmount_Throws()
        {
            // Arrange
            BankAccount account = new BankAccount("Test User", 10.0);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(-5.0),
                "Negative credit should throw ArgumentOutOfRangeException");
        }
    }
}
