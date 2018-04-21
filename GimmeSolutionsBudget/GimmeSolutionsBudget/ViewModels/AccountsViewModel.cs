using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GimmeSolutionsBudget.Models;
using GimmeSolutionsBudget.Views;

namespace GimmeSolutionsBudget.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        public ObservableCollection<Account> Accounts { get; set; }
        public Command LoadAccountsCommand { get; set; }

        public AccountsViewModel()
        {
            Title = "Browse";
            Accounts = new ObservableCollection<Account>();
            LoadAccountsCommand = new Command(async () => await ExecuteLoadAccountsCommand());

            MessagingCenter.Subscribe<NewAccountPage, Account>(this, "AddItem", async (obj, account) =>
            {
                var _account = account as Account;
                Accounts.Add(_account);
                await DataStore.AddAccountAsync(_account);
            });
        }

        async Task ExecuteLoadAccountsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Accounts.Clear();
                var items = await DataStore.GetAccountsAsync(true);
                foreach (var item in items)
                {
                    Accounts.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}