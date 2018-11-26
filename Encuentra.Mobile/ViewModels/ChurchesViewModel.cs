using System;
using System.Collections.ObjectModel;
using Encuentra.Mobile.Model;
using Encuentra.Mobile.Service;
using Encuentra.Mobile.Storage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Encuentra.Mobile.ViewModels
{
    public class ChurchesViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;
        private readonly ApiRestEncuentra apiRestEncuentra;
        private readonly AppData appData;

        public ChurchesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            apiRestEncuentra = new ApiRestEncuentra();
            appData = new AppData();

            SelectChurchCommand = new DelegateCommand<Church>(SelectChurch);
            apiRestEncuentra.GetChurchesFromCity_Completed += (s, a) =>
            {
                Churches = new ObservableCollection<Church>(a.Result);
            };
        }

        private async void SelectChurch(Church _church)
        {
            NavigationParameters navigationParameter = new NavigationParameters
            {
                { "church_detail", _church }
            };
            await _navigationService.NavigateAsync("church_detail", navigationParameter);
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
            string city = string.Empty;
            if (parameters.ContainsKey("city"))
            {
                city = parameters["city"].ToString();
                appData.IdState = city;
            }
            else
            {
                city = appData.IdState;
            }
            apiRestEncuentra.GetChurchesFromCity(city);
            Title = $"Iglesias de {city}";
        }

        public DelegateCommand<Church> SelectChurchCommand { get; private set; }
    }
}
