using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestTotalTech.Views;
using Prism.Unity;
using TestTotalTech.ViewModels;
using TestTotalTech.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestTotalTech
{
    public partial class App : PrismApplication
    {

        protected override void OnInitialized()
        {
            InitializeComponent();
            //NavigationService.NavigateAsync("NavigationPage/ListaDetallePage");
            Session s = new Session();
            if (!string.IsNullOrEmpty(s.Token))
            {
                NavigationService.NavigateAsync("NavigationPage/ListaDetallePage");
            }
            else
            {
                NavigationService.NavigateAsync("LoginPage");
            }
        }


        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<LoginPage, LoginViewModel>();
            Container.RegisterTypeForNavigation<ListaDetallePage, ListaDetalleViewModel>();
            Container.RegisterTypeForNavigation<DetallePage,DetalleViewModel>();
        }

    }
}
