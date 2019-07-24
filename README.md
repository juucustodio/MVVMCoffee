![Icon](/Resources/MVVMCoffee.png)  
# MVVMCoffee 


Nuget package with base class to work with MVVM (Model View ViewModel) without dependence of framework. Save time with this library and enjoy to drink coffee. ☕


 ###### This plugin, works on iOS, Android
 
 **NuGet**

|Name|Info|
| ------------------- | :------------------: |
|MVVMCoffee|[![NuGet](https://img.shields.io/badge/nuget-1.0.1-blue.svg)](https://www.nuget.org/packages/MVVMCoffee/)|



 **Platform Support**
 
 MVVMCoffee is a .NET Standard 2.0 library.Its only dependency is the Xamarin.Forms
 
 
 
 ## Setup / Usage

Install the package in the shared project and use.



### Using in your Model class

```csharp

using MVVMCoffee.Models;

namespace Demo.Models
{
    public class Customer : BaseModel
    {
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        string _name = string.Empty;
    }
}


```


### Using in your ViewModel class
```csharp
using MVVMCoffee.ViewModels;

namespace Demo.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
    
    ...

```

## Navigation methods

PushAsync
```chsarp
await Navigation.PushAsync<CustomerViewModel>(false);
```


SetRootAsync
```chsarp
await Navigation.SetRootAsync<CustomerViewModel>();
```
 
 

PopAsync

```chsarp
await Navigation.PopAsync();
```



PopToRootAsync

```chsarp
await Navigation.PopToRootAsync();
```
