using MVVMCoffee.ViewModels;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command PushAsyncToFormCommand { get; }
        public Command SetRootFormCommand { get; }
        public MainViewModel()
        {
            TitlePage = "MainPage";

            PushAsyncToFormCommand = new Command(ExecutePushAsyncToFormCommand);
            SetRootFormCommand = new Command(ExecuteSetRootFormCommand);

        }

        private async void ExecutePushAsyncToFormCommand()
        {
            await Navigation.PushAsync<FormViewModel>(false);
        }

        private async void ExecuteSetRootFormCommand()
        {
            await Navigation.SetRootAsync<FormViewModel>();
        }
    }
}
