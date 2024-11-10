using System;
using System.Collections.Generic;

namespace BankingProgram
{
    // Bank class
    public class Bank
    {
        // Creating a list that stores accounts
        private static List<Account> _accounts = new List<Account>(); 
        // Creating a list to save transactions
        private static List<Transactions> _transactions = new List<Transactions>();

        public Bank()
        {}

        // Method to add an account to the list
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        // Method to retrieve account using account name
        public Account GetAccount(string name)
        {
            for (int i = 0; i < _accounts.Count; i++)
            {
                if (_accounts[i].Name == name)
                {
                    return _accounts[i];
                }
            }
            return null;
        }

        // Method to withdraw money
        public void ExecuteTransaction(Transactions transaction)
        {
            _transactions.Add(transaction);
            transaction.Execute();
        }
        // Method to print transactio history
        public void PrintTransactionHistory()
        {
            foreach (var transaction in _transactions)
            {
                Console.WriteLine("____________________________");
                transaction.Print();
                Console.WriteLine(transaction._dateStamp);
                Console.WriteLine("____________________________");
            }
        }
        
    }
}


