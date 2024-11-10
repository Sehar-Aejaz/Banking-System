using System;

//Naming the space so that another file can refer to it when using its functions
namespace BankingProgram
{
    public abstract class Transactions
    {
        //Declaring variables for the class
        protected decimal _amount;
        private bool _executed = false;
        protected bool _reverse = false;// changed the scope of reversed because private reverse was inaccessible
        public DateTime _dateStamp;

        public abstract bool Success { get; }

        //Initializes the Transaction class
        public Transactions(decimal amount)
        {
            _amount = amount;
        }

        // Placeholder abstract method for printing transaction details
        public abstract void Print();

        // Virtual method to execute the transaction
        public virtual void Execute()
        {
            // Throw an exception if the transaction has already been executed
            if (_executed)
            {
                throw new InvalidOperationException("Transaction has already been executed.");
            }

            // Set _executed to true
            _executed = true;

            // Assign _dateStamp the current time
            _dateStamp = DateTime.Now;
        }

        // Virtual method to rollback the transaction
        public virtual void Rollback()
        {
            // Throw an exception if the transaction has not been executed
            if (!_executed)
            {
                throw new InvalidOperationException("Transaction has not been executed.");
            }

            // Throw an exception if the transaction has already been reversed
            if (_reverse)
            {
                throw new InvalidOperationException("Transaction has already been reversed.");
            }

            // Set _reversed to true
            _reverse = true;
        }
    }
}
        

