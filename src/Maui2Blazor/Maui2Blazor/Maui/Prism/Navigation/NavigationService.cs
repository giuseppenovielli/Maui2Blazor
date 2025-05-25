using Maui2Blazor.Maui.Services;

namespace Maui2Blazor.Maui.Prism
{
    public class NavigationService : INavigationService
    {
        readonly INavigationPageService _navigationPageService;
        readonly IContainerProvider _containerProvider;

        public NavigationService(
            INavigationPageService navigationPageService,
            IContainerProvider containerProvider)
        {
            _navigationPageService = navigationPageService;
            _containerProvider = containerProvider;
        }

        public async Task<object> GoBackAsync(INavigationParameters parameters = null)
        {
            Dictionary<string, object> navParams = null;
            if (parameters != null)
                navParams = parameters.ToDictionary();

            var navPage = _navigationPageService.GetNavigationPage();
            navPage?.PopPage(navParams);
            return await Task.FromResult(true);
        }

        public async Task<object> NavigateAsync(string uri, INavigationParameters parameters = null)
        {
            var typePage = _containerProvider.GetTypeFromContainer(uri);

            var viewModel = _navigationPageService.ResolveViewModelForPage(typePage);
            var navPage = _navigationPageService.GetNavigationPage();
            navPage?.PushAsync(typePage, parameters?.ToDictionary(), viewModel);
            return await Task.FromResult(true);
        }
    }
}

