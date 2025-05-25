using System.Windows.Input;
using Maui2Blazor.Maui;
using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Maui.ViewModels;
using Maui2BlazorSamples.Views.CollectionView;
using Maui2BlazorSamples.Views.HelloWorld;

namespace Maui2BlazorSamples.ViewModels
{
    public class MainPageViewModel : ViewModelBase
	{
		public ICommand HelloWorldClickCommand { get; private set; }
        public ICommand CollectioViewClickCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
		{
		}

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            HelloWorldClickCommand = new Command(async () =>
            {
                var navResult = await NavigationService.NavigateAsync(nameof(HelloWorldPage));
            });

            CollectioViewClickCommand = new Command(async () =>
            {
                var navResult = await NavigationService.NavigateAsync(nameof(CollectionViewPage));
            });
        }
    }
}

