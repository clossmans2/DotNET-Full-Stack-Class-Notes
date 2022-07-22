using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads
{
    public class Person
    {
        private BankAccount _bankAccount;

        public string Name { get; set; }

        public Person(string name, BankAccount account)
        {
            Name = name;
            _bankAccount = account;
        }

        public void Add(double amt)
        {
            double newBalance = this._bankAccount.DepositMoney(amt);
            Console.WriteLine($"{this.Name} deposited {amt}, new balance is {newBalance}");
        }

        public void Withdraw(double amt)
        {
            var oldBalance = this._bankAccount.Balance;
            double newBalance = this._bankAccount.WithdrawMoney(amt);
            if (newBalance != oldBalance)
            {
                Console.WriteLine($"{this.Name} withdrew {amt}, new balance is {newBalance}");
            }
        }
    }
}
