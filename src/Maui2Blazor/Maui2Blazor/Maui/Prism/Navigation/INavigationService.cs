namespace Maui2Blazor.Maui.Prism
{
    public interface INavigationService
    {
        Task<object> NavigateAsync(string uri, INavigationParameters parameters = null);
        Task<object> GoBackAsync(INavigationParameters parameters = null);
    }

}

