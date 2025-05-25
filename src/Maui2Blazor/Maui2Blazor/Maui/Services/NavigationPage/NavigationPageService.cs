using Maui2Blazor.Maui.Controls;
using Maui2Blazor.Maui.Extensions;

namespace Maui2Blazor.Maui.Services
{
    public class NavigationPageService : INavigationPageService
    {
        NavigationPage _navigationPage;
        Dictionary<Type, Type> _pageToViewModelMap { get; } = new();

        public event Action<Dictionary<Type, Type>> OnRegisterPageToViewModelMap;


        public NavigationPageService()
        {
        }

        public void RegisterPageToViewModelMap()
        {
            OnRegisterPageToViewModelMap?.Invoke(_pageToViewModelMap);
        }

        public void RegisterNavigationPage(NavigationPage navigationPage)
        {
            _navigationPage = navigationPage;
        }

        public NavigationPage GetNavigationPage()
        {
            return Maui2BlazorApp.NavigationPage;
            if (_navigationPage == null)
            {
                throw new InvalidOperationException("NavigationPage non è stata registrata.");
            }
            return _navigationPage;
        }

        public object ResolveViewModelForPage(Type pageType)
        {
            if (_pageToViewModelMap.TryGetValue(pageType, out Type viewModelType))
            {
                var viewModelInstance = Maui2BlazorApp.IOCContainer.Resolve(viewModelType);
                return viewModelInstance;
            }
            return null;
        }

        
    }
}

