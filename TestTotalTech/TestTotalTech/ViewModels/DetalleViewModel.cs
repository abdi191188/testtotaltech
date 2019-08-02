using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TestTotalTech.Models;

namespace TestTotalTech.ViewModels
{
    public class DetalleViewModel : ViewModelBase, INavigationAware
    {
        
        public DetalleViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters){}
        public void OnNavigatingTo(NavigationParameters parameters) { }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this.Detalle = parameters.GetValue<Persona>("persona");

            Source1 = "https://maps.google.com/?q=" + this.Detalle.latitud.ToString() + "," + this.Detalle.longitud.ToString() + "";
            //https://maps.google.com/?q=51.03841,-114.01679
        }




        public Persona _Detalle;
        public Persona Detalle
        {
            get
            {
                return _Detalle;
            }
            set
            {
                Set(ref _Detalle, value);
            }
        }

        public string _Source1;
        public string Source1
        {
            get
            {
                return _Source1;
            }
            set
            {
                Set(ref _Source1, value);
            }
        }

    }
}
