using System;
//Naming the space so that another file can refer to it when using its functions
namespace BankingProgram;


public class Account
    {
        //Declaring Private varibles for the class
        private decimal _balance;
        private string _name;

        //Initialises the Account class
        public Account(string name, decimal startingBalance)
        {
            _name = name;
            _balance = startingBalance;
        }

        //Adds money to existing balance
        public bool Deposit(decimal amountToAdd)
        {
            //check if amount is negative
            if (amountToAdd > 0)
            {
                _balance = _balance + amountToAdd;
                return true;
            }
            return false;
        }
        
        //Withdraws money from existing balance
        public bool Withdraw(decimal amountToWithdraw)
        {
            //check if amount is neagtive and isn't more than the balance
            if((amountToWithdraw > 0) && (amountToWithdraw < _balance))
            {
                _balance = _balance - amountToWithdraw;
                return true;
            }
            return false;
        }

        //Returns account holder name
        public string Name
        {
            get {return _name;}
        }

        //Prints the name and balance
        public void Print()
        {
            Console.WriteLine($"Name : {_name}\nBalance : {_balance}");
        }
       
    }

