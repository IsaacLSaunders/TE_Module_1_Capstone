using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Capstone.Classes
{
    public class Accountant
    {
        public decimal Balance { get; private set; } = 0.00M;

        private decimal IncrementBalance(decimal moneyIn)
        {
            Balance += moneyIn;
            return Balance;
        }
        private decimal DecrementBalance(decimal itemPrice)
        {
            Balance -= itemPrice;
            return Balance;
        }

        private bool DispenseChange()
        {
            bool success = false;

            int balanceAsPennies = (int)(Balance * 100);
            int numberOfQuarters = 0;
            int numberOfDimes = 0;
            int numberOfNickles = 0;

            int remainderFromQuarters = balanceAsPennies % 25;
            numberOfQuarters = (balanceAsPennies - remainderFromQuarters) / 25;

            int remainderFromDimes = remainderFromQuarters % 10;
            numberOfDimes = (remainderFromQuarters - remainderFromDimes) / 10;

            int remainderFromNickles = remainderFromDimes % 5;
            numberOfNickles = (remainderFromDimes - remainderFromNickles) / 5;

            Console.WriteLine($"Your balance was {Balance}. Your change is {numberOfQuarters} quarters, {numberOfDimes} dimes, and {numberOfNickles} nickles.");

            Balance = 0.00M;

            Console.WriteLine($"Your balance is now {Balance}.");

            success = true;

            return success;
        }


    }
}
