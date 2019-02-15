using System.Threading.Tasks;
using MVVMCoffee.Models;
using MVVMCoffee.Services;

namespace MVVMCoffee.ViewModels
{
    public class BaseViewModel : BaseModel
    {

        private bool _ocupado;
        public bool Ocupado
        {
            get { return _ocupado; }
            set
            {
                SetProperty(ref _ocupado, value);
            }
        }

        private string _titlePage;
        public string TitlePage
        {
            get { return _titlePage; }
            set
            {
                SetProperty(ref _titlePage, value);
            }
        }

        public virtual Task LoadAsync(object[] args) => Task.FromResult(true);

        public virtual Task LoadAsync() => Task.FromResult(true);

        protected NavigationService Navigation => NavigationService.Current;
    }
}

