using System;
//Naming the space so that another file can refer to it when using its functions
namespace BankingProgram;


 public class DepositTransaction : Transactions
 {
    private Account _account; 
    private bool _success = false; 
    public override bool Success 
    {
        get 
        {
            return _success; 
        }
    }
    
    //Constructor
    public DepositTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }
   
     //Method to deposit
    public override void Execute()
    {
        base.Execute(); // Call base Execute method to set timestamp and executed

        // Execute deposit
        _success = _account.Deposit(_amount); 
    }
    //Method to rollback
    public override void Rollback()
    {
        base.Rollback(); // Call base Rollback method to check execution

        // Rollback by withdrawing the deposited amount
        _account.Withdraw(_amount);
    }

    //Methos to print
    public override void Print() 
    {
        if (_success) 
        {
            Console.WriteLine($"Transaction was successful\nAmount Deposited to {_account.Name}: {_amount}\n");
            _account.Print();
        }
        if (_reverse) Console.WriteLine("The transaction performed was reversed\n");
    } 
    
}