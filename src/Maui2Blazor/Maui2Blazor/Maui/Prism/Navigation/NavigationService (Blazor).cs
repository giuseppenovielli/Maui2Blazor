using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Prism
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationManager _navigationManager;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public Task<object> NavigateAsync(string uri, INavigationParameters parameters = null)
        {
            if (parameters != null && parameters.GetAllParameters().Any())
            {
                var queryString = string.Join("&", parameters.GetAllParameters()
                    .Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value.ToString())}"));

                uri = $"{uri}?{queryString}";
            }

            _navigationManager.NavigateTo(uri);
            return null;
        }

        public Task<object> GoBackAsync(INavigationParameters parameters = null)
        {
            _navigationManager.NavigateTo("javascript:history.back()");
            return null;
        }
    }
}

