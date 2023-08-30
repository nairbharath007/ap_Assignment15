using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Model
{
    [Serializable]
    class Account
    {
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }

        public Account(int accountNumber, string accountHolderName, string bankName, double balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            BankName = bankName;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
                Balance += amount;
            else
                Console.WriteLine("Invalid deposit amount.");
        }

        public void Withdraw(double amount)
        {
            if (Balance - amount >= 500)
                Balance -= amount;
            else
                Console.WriteLine("Insufficient balance.");
        }

        public double CheckBalance()
        {
            return Balance;
        }
    }
}
