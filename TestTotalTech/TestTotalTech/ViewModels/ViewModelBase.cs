using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Runtime.CompilerServices;

namespace TestTotalTech.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        public  INavigationService NavigationService;

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
