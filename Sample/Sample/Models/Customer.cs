using MVVMCoffee.Models;

namespace Sample.Models
{
    public class Customer : BaseModel
    {
        //In your model class, heritage of BaseModel class
        //to use the SetProperty method,
        //with this you will use the INotifyPropertyChanged
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        string _name = string.Empty;

        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }
        int _age;
    }
}
