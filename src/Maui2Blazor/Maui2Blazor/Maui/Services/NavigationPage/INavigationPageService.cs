using Maui2Blazor.Maui.Controls;

namespace Maui2Blazor.Maui.Services
{
    public interface INavigationPageService
	{
        event Action<Dictionary<Type, Type>> OnRegisterPageToViewModelMap;

        void RegisterNavigationPage(NavigationPage navigationPage);
        NavigationPage GetNavigationPage();


        object ResolveViewModelForPage(Type pageType);
    }
}

