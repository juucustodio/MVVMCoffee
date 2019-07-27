using System;
using MVVMCoffee.ViewModels;
using Sample.Models;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class FormViewModel : BaseViewModel
    {
        public Command PopAsyncCommand { get; }
        public Command PopToRootAsyncCommand { get; }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }

        public FormViewModel()
        {
            TitlePage = "FormPage";
            Customer = new Customer();

            PopAsyncCommand = new Command(ExecutePopAsyncCommand);
            PopToRootAsyncCommand = new Command(ExecutePopToRootAsyncCommand);
        }

        private async void ExecutePopAsyncCommand()
        {
            await Navigation.PopAsync();
        }

        private async void ExecutePopToRootAsyncCommand()
        {
            await Navigation.PopToRootAsync();
        }
    }
}
