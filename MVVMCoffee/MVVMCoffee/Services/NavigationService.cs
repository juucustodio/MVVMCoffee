using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using MVVMCoffee.ViewModels;

namespace MVVMCoffee.Services
{
    public class NavigationService
    {
        static Lazy<NavigationService> LazyNavi = new Lazy<NavigationService>(() => new NavigationService());
        public static NavigationService Current => LazyNavi.Value;

        private Page GetViewModelLocator<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            Type viewModelType = typeof(TViewModel);
            string viewModelTypeName = viewModelType.Name;
            int viewModelWordLength = "ViewModel".Length;

            string[] namespaceSplit = typeof(TViewModel).AssemblyQualifiedName.Split('.');
            string namespaceName = namespaceSplit[0];

            int x = 1;
            while (namespaceSplit[x] != "ViewModels")
            {
                namespaceName += "." + namespaceSplit[x];
                x++;
            }

            string viewTypeName = $"{namespaceName}.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";

            Type viewType = Type.GetType(viewTypeName + "," + namespaceName + ".dll");

            Page page = Activator.CreateInstance(viewType) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);

            if (page != null)
                page.BindingContext = viewModel;

            return page;
        }

        public async Task PushAsync<TViewModel>(bool modal = false, params object[] args) where TViewModel : BaseViewModel
        {
            Page page = GetViewModelLocator<TViewModel>(args);
            int count = Application.Current.MainPage.Navigation.NavigationStack.Count -1;
            if (Application.Current.MainPage.Navigation.NavigationStack[count].GetType().ToString() != page.GetType().ToString())
            {
                if (modal)
                    await Application.Current.MainPage.Navigation.PushModalAsync(page);
                else
                    await Application.Current.MainPage.Navigation.PushAsync(page);

                await (page.BindingContext as BaseViewModel).LoadAsync(args);
            }
        }

        public async Task SetRootAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            Page page = GetViewModelLocator<TViewModel>(args);

            Application.Current.MainPage = new NavigationPage(page);

            await (page.BindingContext as BaseViewModel).LoadAsync(args);
        }

        public async Task PopAsync(bool modal = false)
        {
            if(modal)
                await Application.Current.MainPage.Navigation.PopModalAsync();
            else
                await Application.Current.MainPage.Navigation.PopAsync();
        }
        
        public async Task PopToRootAsync() =>
          await Application.Current.MainPage.Navigation.PopToRootAsync();
    }
}