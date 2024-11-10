using System;
using SplashKitSDK;

namespace BankingProgram;

// Enumeration for menu
public enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
    NewAccount,
    Transaction_History,
    Quit
}

public class Program
{
        public static void Main()
        {
            Bank _bank = new Bank();

            MenuOption userSelection;

            // Loop until user chooses to quit
            do
            {
                userSelection = ReadUserOption();

                // Perform actions based on user's choice
                switch (userSelection)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(_bank);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(_bank);
                        break;
                    case MenuOption.Transfer:
                        DoTransaction(_bank);
                        break;
                    case MenuOption.Print:
                        DoPrint(_bank);
                        break;
                    case MenuOption.NewAccount:
                        Console.Write("Enter account name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the account's starting balance: ");
                        decimal balance = -1;
                        do
                        {
                            try
                            {
                                balance = Convert.ToDecimal(Console.ReadLine());
                                if (balance < 0)
                                {
                                    Console.WriteLine("Balance should be greater than 0");
                                    balance = -1;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter valid balance value");
                            }

                        } while (balance == -1);
                        
                        Account account_add = new Account(name, balance);
                        _bank.AddAccount(account_add);
                        break;
                    case MenuOption.Transaction_History:
                        _bank.PrintTransactionHistory();
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Quitting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (userSelection != MenuOption.Quit);

        }

        // Method to deposit money
        private static void DoDeposit(Bank toBank)  
        {
            Account toAccount = FindAccount(toBank);
            if (toAccount == null) return;

            decimal value;
            Console.WriteLine("How much money would you like to deposit?\n");
            value = Convert.ToDecimal(Console.ReadLine());
            
            DepositTransaction deposit = new DepositTransaction(toAccount, value);
            toBank.ExecuteTransaction(deposit); // using bank object to perform function
            deposit.Print();
        }

        // Method to withdraw money
        private static void DoWithdraw(Bank fromBank) 
        { 
            Account fromAccount = FindAccount(fromBank);
            if (fromAccount == null) return;
            decimal value;
            Console.WriteLine("How much money would you like to withdraw?\n");
            value = Convert.ToDecimal(Console.ReadLine());

            WithdrawTransaction withdraw = new WithdrawTransaction(fromAccount, value);
            fromBank.ExecuteTransaction(withdraw); // using bank object to perform function
            withdraw.Print();
        }
        // Method to do transcations between two accounts
        private static void DoTransaction(Bank _bank) 
        {
            Console.WriteLine("The first account for transaction");
            Account fromAccount = FindAccount(_bank);
            if (fromAccount == null) return;
            Console.WriteLine("The second account for transaction");
            Account toAccount = FindAccount(_bank);
            if (toAccount == null) return;

            decimal value;
            Console.WriteLine("How much money would you like to transfer?\n");
            value = Convert.ToDecimal(Console.ReadLine());

            TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, value);
            _bank.ExecuteTransaction(transfer); // using bank object to perform function
            transfer.Print();
        }

        // Method to print balance
        private static void DoPrint(Bank _bank) 
        {
            Account bankAccount = FindAccount(_bank);
            if (bankAccount == null) return;
            bankAccount.Print();
        }

        // Method to read user's menu option choice
        private static MenuOption ReadUserOption()
        {
            int option;

            Console.WriteLine("************************");
            Console.WriteLine("* 1 Withdraw           *");
            Console.WriteLine("* 2 Deposit            *");
            Console.WriteLine("* 3 Transaction        *");
            Console.WriteLine("* 4 Print              *");
            Console.WriteLine("* 5 New Account        *");
            Console.WriteLine("* 6 Transaction History*");
            Console.WriteLine("* 7 Quit               *");
            Console.WriteLine("************************");

            // Loop until valid option is chosen
            do
            {
                try
                {
                    Console.Write("Choose an option [1-7]: ");
                    option = Convert.ToInt32(Console.ReadLine());

                    if (option < 1 || option > 7)
                    {
                        Console.WriteLine("Invalid option. Please choose between 1 and 7.");
                        option = -1;
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a number. Try again.");
                    option = -1;
                }
            } while (option == -1);

            return (MenuOption)(option - 1);
        }
        
        // Method to find account from user name
         private static Account FindAccount(Bank fromBank) 
         {
            Console.Write("Enter account name: "); 
            String name = Console.ReadLine();
            Account result = fromBank.GetAccount(name);
            if ( result == null ) 
            {
                Console.WriteLine($"No account found with name {name}"); 
            }
            return result; 
         }


}

