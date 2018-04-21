using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GimmeSolutionsBudget.Models;
using GimmeSolutionsBudget.ViewModels;

namespace GimmeSolutionsBudget.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountDetailPage : ContentPage
	{
        AccountDetailViewModel viewModel;

        public AccountDetailPage(AccountDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public AccountDetailPage()
        {
            InitializeComponent();

            var item = new Account
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new AccountDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}