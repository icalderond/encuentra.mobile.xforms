using Encuentra.Mobile.Model;
using Prism.Mvvm;
using Prism.Navigation;
namespace Encuentra.Mobile.ViewModels
{
    public class ChurchDetailsViewModel : BindableBase, INavigatedAware
    {
        public ChurchDetailsViewModel() { }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var church = parameters.GetValue<Church>("church_detail");
            ChurchDetail = church;

            Title = church.nombre;
        }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }
        private Church _ChurchDetail;
        public Church ChurchDetail
        {
            get => _ChurchDetail;
            set => SetProperty(ref _ChurchDetail, value);
        }
    }
}