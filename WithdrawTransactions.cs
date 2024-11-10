using System;
//Naming the space so that another file can refer to it when using its functions
namespace BankingProgram;


 public class WithdrawTransaction : Transactions
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
    public WithdrawTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
        //_amount = amount; 
    }

    //Method to withdraw
    public override void Execute()
    {
        base.Execute(); // Call base Execute method to set timestamp and executed

        // Execute withfraw
        _success = _account.Withdraw(_amount); 
    }
    // Method to Rollback in case of unsuccessful transaction
    public override void Rollback()
    {
        base.Rollback(); // Call base Rollback method to check execution

        // Rollback by depositing the withdrawn amount
        _account.Deposit(_amount);
    }
    //Method to print
    public override void Print() 
    {
        if (_success) 
        {
            Console.WriteLine($"Transaction was successful\nAmount Withdrawn from {_account.Name}: {_amount}\n");
            _account.Print();
        }
        if (_reverse) Console.WriteLine("The transaction performed was reversed\n");
    } 
    
}