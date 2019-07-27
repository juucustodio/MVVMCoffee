using System.ComponentModel;
using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
