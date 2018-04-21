using System;
using System.Collections.Generic;
using System.Text;

namespace GimmeSolutionsBudget.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public Category BudgetCategory { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
