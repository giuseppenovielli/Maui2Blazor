using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Mopups
{
    public interface IPopupNavigation
    {
        Task<PopupPage> PushAsync(Type pageType, Dictionary<string, object> parameters = null);
        Task PopAsync();
        bool IsPopupOpen { get; }

        PopupPage GetCurrentPopupPage();
        RenderFragment GetCurrentPopupContent();

        event Action OnPopupChange;
    }

}

