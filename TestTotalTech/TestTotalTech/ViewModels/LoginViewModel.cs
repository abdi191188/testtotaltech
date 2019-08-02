using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TestTotalTech.Models;
using TestTotalTech.Services;
using TestTotalTech.UserControl;
using Xamarin.Forms;

namespace TestTotalTech.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {

            #if DEBUG
            //Usuario = "eve.holt@reqres.in";
            //Password = "cityslicka";
            //SignInCommand.Execute(null);
            #endif

        }

        private string usuario;
        /// <summary>
        /// Obtiene o asigna el usuario
        /// </summary>
        public string Usuario
        {
            get => usuario;
            set
            {
                Set(ref usuario, value);
            }
        }

        private string password;
        /// <summary>
        /// Obtiene o asigna la contraseña
        /// </summary>
        public string Password
        {
            get => password;
            set
            {
                Set(ref password, value);
            }
        }

        #region SignInCommand
        Command<string> signInCommand = null;
        /// <summary>
        /// Obtiene el comando para ejecutar la autenticación
        /// </summary>
        public Command<string> SignInCommand
        {
            get => signInCommand ?? (signInCommand = new Command<string>(async (o) =>
            {
                try
                {
                    UserApi api = new UserApi();
                    bool b = await api.LoginOn(Usuario,Password);
                    if (b)
                    {
                        await NavigationService.NavigateAsync("NavigationPage/ListaDetallePage");
                    }
                    else
                    {
                        XToast.LongMessage("El usuario o contraseña son incorrectos.");
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
