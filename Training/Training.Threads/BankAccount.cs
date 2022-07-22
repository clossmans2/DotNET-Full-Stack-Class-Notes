using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads
{
    public class BankAccount
    {
        private readonly object mutex = new object();
        public double Balance { get; set; }

        public BankAccount(double balance)
        {
            Balance = balance;
        }

        public double DepositMoney(double amount)
        {
            lock (mutex)
            {
                Balance += amount;
            }            
            return Balance;
        }

        public double WithdrawMoney(double amount)
        {
            lock (mutex)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            return Balance;
        }
    }
}
