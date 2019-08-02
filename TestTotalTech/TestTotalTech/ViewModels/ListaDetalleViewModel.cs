using Prism.Navigation;
using System;
using System.Collections.Generic;
using TestTotalTech.Models;
using TestTotalTech.Services;
using TestTotalTech.UserControl;
using Xamarin.Forms;

namespace TestTotalTech.ViewModels
{
    public class ListaDetalleViewModel : ViewModelBase
    {

        public ListaDetalleViewModel(INavigationService navigationService) : base(navigationService)
        {
            detalle.Execute(null);
        }


        public Command<string> detalle
        {
            get
            {
                return new Command<string>(async (value) =>
                {
                    PersonasApi p = new PersonasApi();
                    RootObject ro = await p.GetPersonas(5);

                    List<Result> l = ro.results;
                    List<Persona> col = new List<Persona>();
                    for (int i = 0; i < l.Count; i++)
                    {
                        Persona pe = new Persona();
                        pe.Name = l[i].name.first;
                        pe.Email = l[i].email;
                        pe.Location = l[i].location.street;
                        Random r = new Random();
                        pe.rating = r.Next(1,5);
                        pe.Ciudad = l[i].location.city;
                        pe.Calle = l[i].location.street;
                        pe.CodigoPostal = l[i].location.postcode.ToString();
                        pe.latitud = double.Parse(l[i].location.coordinates.latitude);
                        pe.longitud = double.Parse(l[i].location.coordinates.longitude);
                        pe.ImageUrl = l[i].picture.large;
                        col.Add(pe);
                    }

                    this.Personas = col;
                }
            );
            }
        }


        public List<Persona> _Personas;
        public List<Persona> Personas
        {
            get
            {
                return _Personas;
            }
            set
            {
                Set(ref _Personas, value);
            }
        }

        #region ItemSelected
        public Command<ItemTappedEventArgs> ItemSelected
        {
            get
            {
                // return new Command<SelectedItemChangedEventArgs>((e) =>  // no async
                return new Command<ItemTappedEventArgs>((e) =>
                {
                    Persona per = e.Item as Persona;

                    NavigationParameters obj = new NavigationParameters();
                    obj.Add("persona",per);
                    NavigationService.NavigateAsync("NavigationPage/DetallePage",obj);

                });
            }
        }
        #endregion


        #region SignInCommand
        Command<string> _Close = null;
        /// <summary>
        /// Obtiene el comando para ejecutar la autenticación
        /// </summary>
        public Command<string> Close
        {
            get => _Close ?? (_Close = new Command<string>(async (o) =>
            {
                try
                {
                    bool answer = await App.Current.MainPage.DisplayAlert("Test", "¿Desea finalizar su sesion?", "Si", "No");
                    if (answer)
                    {
                        Session s = new Session();
                        if (!string.IsNullOrEmpty(s.Token))
                        {
                            s.ClearSession();
                        }
                        await NavigationService.NavigateAsync("/LoginPage");
                    }
                }
                catch (Exception ex)
                {
                    XToast.LongMessage(ex.Message);
                }

            }, (o) => { return true; }));
        }
        #endregion

    }
}
