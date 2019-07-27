using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class FormPage : ContentPage
    {
        private FormViewModel ViewModel => BindingContext as FormViewModel;
        public FormPage()
        {
            InitializeComponent();
            BindingContext = new FormViewModel();
        }
    }
}
