using System;
//Naming the space so that another file can refer to it when using its functions
namespace BankingProgram;


 public class TransferTransaction : Transactions
 {
    private Account _toAccount; 
    private Account _fromAccount; 
    private DepositTransaction _theDeposit;
    private WithdrawTransaction _theWithdraw;
    public override bool Success 
    {
        get 
        {
            return (_theDeposit.Success && _theWithdraw.Success); 
        }
    }
    
    //Constructor
    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
    {
        _toAccount = toAccount;
        _fromAccount = fromAccount;
        //_amount = amount; 
        _theDeposit = new DepositTransaction(toAccount, amount);
        _theWithdraw = new WithdrawTransaction(fromAccount, amount); 
        
        
    }
    //Method to execute transaction
    public override void Execute()
        {
            base.Execute(); // Call base Execute method to set timestamp and executed

            _theWithdraw.Execute();

            if (_theWithdraw.Success)
            {
                _theDeposit.Execute();

                if (!_theDeposit.Success)
                {
                    _theWithdraw.Rollback();
                }
            }
        }

    //Method to rollback
    public override void Rollback()
        {
            base.Rollback(); // Call base Rollback method to check execution

            if (_theWithdraw.Success) _theWithdraw.Rollback();
            if (_theDeposit.Success) _theDeposit.Rollback();
        }
    //Methos to print
    public override void Print() 
    {
        Console.WriteLine($"Transferred ${_amount} from {_fromAccount.Name} to {_toAccount.Name}\n");
        Console.WriteLine("    ");
        _theDeposit.Print();
        Console.WriteLine("    ");
        _theWithdraw.Print();
        
    } 
    
}