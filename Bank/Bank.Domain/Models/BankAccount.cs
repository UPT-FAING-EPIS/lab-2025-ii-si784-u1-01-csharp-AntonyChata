using System; // <- IMPORTANTE

namespace Bank.Domain.Models
{
    public class BankAccount
    {
        public string CustomerName { get; }
        public double Balance { get; private set; }

        public BankAccount(string customerName, double beginningBalance)
        {
            CustomerName = customerName;
            Balance = beginningBalance;
        }

        public void Debit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Amount exceeds balance.");

            Balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");

            Balance += amount;
        }
    }
}
