using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GimmeSolutionsBudget.Models;
using GimmeSolutionsBudget.Views;
using GimmeSolutionsBudget.ViewModels;

namespace GimmeSolutionsBudget.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountsPage : ContentPage
	{
        AccountsViewModel viewModel;

        public AccountsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AccountsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Account;
            if (item == null)
                return;

            await Navigation.PushAsync(new AccountDetailPage(new AccountDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewAccountPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Accounts.Count == 0)
                viewModel.LoadAccountsCommand.Execute(null);
        }
    }
}