using System.ComponentModel;
using Maui2Blazor.Maui.Interfaces;
using Maui2Blazor.Maui.Prism;

namespace Maui2Blazor.Maui.ViewModels
{
    public class ViewModelBase : IDestructible, IApplicationLifecycleAware, IPageLifecycleAware, INavigationAware, IInitialize, INavigationPageOptions, INotifyPropertyChangedExtended
    {
        public bool ClearNavigationStackOnNavigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigationService = null)
        {
            NavigationService = navigationService;
        }


        public virtual void OnResume()
        {

        }

        public virtual void OnSleep()
        {

        }

        public virtual void OnAppearing()
        {

        }

        public virtual void OnDisappearing()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }


        public void Destroy()
        {

        }

        public void OnPropertyChanged(object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}

