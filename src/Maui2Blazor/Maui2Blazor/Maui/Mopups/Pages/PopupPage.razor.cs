using System.Windows.Input;
using Maui2Blazor.Maui.Controls;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Mopups
{
    public partial class PopupPage : ContentPage
    {
        [Inject] private IPopupNavigation PopupNavigation { get; set; }

        /// <summary>
        /// Indica se il popup è aperto.
        /// </summary>
        private bool IsPopupOpen => PopupNavigation.IsPopupOpen;

        /// <summary>
        /// Evento per il click sullo sfondo.
        /// </summary>
        public event EventHandler BackgroundClicked;

        [Parameter] public bool IsAnimationEnabled { get; set; } = true;
        [Parameter] public bool HasSystemPadding { get; set; } = true;
        [Parameter] public string AnimationType { get; set; } = "scale"; // Placeholder per future animazioni
        [Parameter] public bool CloseWhenBackgroundIsClicked { get; set; } = true;
        [Parameter] public bool BackgroundInputTransparent { get; set; } = false;
        [Parameter] public bool HasKeyboardOffset { get; set; } = true;
        [Parameter] public double KeyboardOffset { get; set; } = 0;
        [Parameter] public ICommand BackgroundClickedCommand { get; set; }
        [Parameter] public object BackgroundClickedCommandParameter { get; set; }

        /// <summary>
        /// Chiude il popup.
        /// </summary>
        private async Task ClosePopup()
        {
            await PopupNavigation.PopAsync();
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            PopupNavigation.OnPopupChange += StateHasChanged;
            
        }

        public override void Dispose()
        {
            base.Dispose();
            PopupNavigation.OnPopupChange -= StateHasChanged;
        }

        internal void OnBackgroundClicked()
        {
            BackgroundClicked?.Invoke(this, EventArgs.Empty);

            if (BackgroundClickedCommand?.CanExecute(BackgroundClickedCommandParameter) == true)
            {
                BackgroundClickedCommand.Execute(BackgroundClickedCommandParameter);
            }

            if (CloseWhenBackgroundIsClicked)
            {
                _ = ClosePopup();
            }
        }

        protected override string GetCombinedStyle()
        {
            return null;
            var style = base.GetCombinedStyle();
            style += $@"
                {(BackgroundInputTransparent ? "pointer-events: none;" : "")}
                {(HasKeyboardOffset ? $"margin-bottom: {KeyboardOffset}px;" : "")}
            ";
            return style;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (PopupNavigation is PopupNavigation popupNavigation)
            {
                popupNavigation.Tcs.SetResult(this);
            }
            
        }
    }
}
