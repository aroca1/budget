using System;

using GimmeSolutionsBudget.Models;

namespace GimmeSolutionsBudget.ViewModels
{
    public class AccountDetailViewModel : BaseViewModel
    {
        public Account Item { get; set; }
        public AccountDetailViewModel(Account account = null)
        {
            Title = account?.Name;
            Item = account;
        }
    }
}
