using Maui2Blazor.Utils;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Mopups
{
    public class PopupNavigation : IPopupNavigation
    {
        public TaskCompletionSource<PopupPage> Tcs { get; private set; }

        private RenderFragment _currentPopup;
        private PopupPage _currentPopupPage;

        public bool IsPopupOpen { get; private set; }

        public event Action OnPopupChange;
        public event EventHandler<PopupPage> OnPopupAppearing;

        public async Task<PopupPage> PushAsync(Type pageType, Dictionary<string, object> parameters = null)
        {
            if (!typeof(PopupPage).IsAssignableFrom(pageType))
                throw new InvalidOperationException($"Il tipo {pageType.FullName} non è una pagina valida.");

            Tcs = new TaskCompletionSource<PopupPage>(TaskCreationOptions.RunContinuationsAsynchronously);

            _currentPopup = builder =>
            {
                builder.OpenComponent(0, pageType);

                parameters ??= new Dictionary<string, object>();
                builder.AddAttribute(1, "_Parameters", parameters);

                builder.CloseComponent();
            };            

            DebugHelpers.WriteLine("\nPopupNavigation PushAsync");
            DebugHelpers.WriteLine(pageType);
            DebugHelpers.WriteLine(parameters);
            DebugHelpers.WriteLine(_currentPopup);

            IsPopupOpen = true;
            OnPopupChange?.Invoke();

            var result = await Tcs.Task.ConfigureAwait(false);

            

            return result;
        }

        public Task PopAsync()
        {
            _currentPopup = null;
            IsPopupOpen = false;
            OnPopupChange?.Invoke();
            SetCurrentPopupPage(null);
            DebugHelpers.WriteLine("\nPopupNavigation PopAsync");
            return Task.CompletedTask;
        }

        public RenderFragment GetCurrentPopupContent() => _currentPopup;

        public PopupPage GetCurrentPopupPage() => _currentPopupPage;
        void SetCurrentPopupPage(PopupPage popupPage) => _currentPopupPage = popupPage;

        //public void PopupAppearing(PopupPage popupPage)
        //{
        //    SetCurrentPopupPage(popupPage);
        //    OnPopupAppearing?.Invoke(this, popupPage);
        //}
    }

}

