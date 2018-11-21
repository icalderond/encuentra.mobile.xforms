using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;
using Encuentra.Mobile.Service;
using System.Collections.ObjectModel;
using Encuentra.Mobile.Model;
namespace Encuentra.Mobile.ViewModels
{
    public class CitiesViewModel : BindableBase
    {
        INavigationService _navigationService;
        ApiRestEncuentra apiRestEncuentra;
        public CitiesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            apiRestEncuentra = new ApiRestEncuentra();
            SelectCityCommand = new DelegateCommand<City>(SelectCity);

            apiRestEncuentra.GetCities_Completed += (s, a) =>
            {
                Cities = new ObservableCollection<City>(a.Result);
            };

            Title = "Estados";

            apiRestEncuentra.GetCities();
        }

        private async void SelectCity(City _city)
        {
            NavigationParameters navigationParameter = new NavigationParameters
            {
                { "city", _city.edo }
            };

            await _navigationService.NavigateAsync("churches", navigationParameter);
        }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        private ObservableCollection<City> _Cities;
        public ObservableCollection<City> Cities
        {
            get => _Cities;
            set => SetProperty(ref _Cities, value);
        }

        public DelegateCommand<City> SelectCityCommand { get; private set; }
    }
}