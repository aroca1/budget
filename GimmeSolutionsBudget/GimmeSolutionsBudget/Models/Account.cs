using System;

namespace GimmeSolutionsBudget.Models
{
    public class Account
    {
        public enum AccountType
        {
            Checking,
            Savings,
            Loan,
            Cash,
            CreditCard,
            OtherLiability,
            OtherAsset
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AccountType TypeOfAccount { get; set; }
        public TransactionCollection Transactions { get; set; }
        public double Balance { get { return this.Transactions.GetTotalBalance(); } }
    }
}