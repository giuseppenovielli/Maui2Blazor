using Maui2Blazor.Maui.Controls;
using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Maui.ViewModels;

namespace Maui2Blazor.Maui.Views
{
    public class ContentPageBase : ContentPage, IInitialize, INavigationAware
    {
		public ContentPageBase()
		{
		}

        public void Initialize(INavigationParameters parameters)
        {
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender && BindingContext is ViewModelBase vm)
                vm.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                {
                    InvokeSafeStateHasChanged();
                };
        }
    }
}

