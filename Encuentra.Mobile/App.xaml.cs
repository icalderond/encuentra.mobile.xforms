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
            await NavigationService.NavigateAsync("NavigationPage/cities");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CitiesPage, CitiesViewModel>("cities");
            containerRegistry.RegisterForNavigation<ChurchesPage, ChurchesViewModel>("churches");
            containerRegistry.RegisterForNavigation<ChurchDetailsPage, ChurchDetailsViewModel>("church_detail");
        }
    }
}
