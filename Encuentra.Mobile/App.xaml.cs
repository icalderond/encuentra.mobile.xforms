using System;
using Encuentra.Mobile.Service;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Encuentra.Mobile.Views;
using Encuentra.Mobile.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Encuentra.Mobile
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            ApiRestEncuentra apiRestEncuentra = new ApiRestEncuentra();
            apiRestEncuentra.GetCities();

            await NavigationService.NavigateAsync("NavigationPage/cities");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CitiesPage, CitiesViewModel>("cities");
        }
    }
}
