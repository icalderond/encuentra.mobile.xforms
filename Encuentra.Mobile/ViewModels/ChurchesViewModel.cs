using System;
using Encuentra.Mobile.Service;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Encuentra.Mobile.Model;
namespace Encuentra.Mobile.ViewModels
{
    public class ChurchesViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;
        private readonly ApiRestEncuentra apiRestEncuentra;

        public ChurchesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            apiRestEncuentra = new ApiRestEncuentra();

            apiRestEncuentra.GetChurchesFromCity_Completed += (s, a) =>
            {
                Churches = new ObservableCollection<Church>(a.Result);
            };
        }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        private ObservableCollection<Church> _Churches;
        public ObservableCollection<Church> Churches
        {
            get => _Churches;
            set => SetProperty(ref _Churches, value);
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var city = parameters["city"].ToString();
            apiRestEncuentra.GetChurchesFromCity(city);


            Title = $"Iglesias de {city}";

        }
    }
}
