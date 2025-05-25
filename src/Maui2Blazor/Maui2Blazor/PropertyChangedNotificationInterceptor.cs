using Maui2Blazor.Maui.Controls;
using Maui2Blazor.Maui.Interfaces;
using Maui2Blazor.Utils;

namespace Maui2Blazor
{
    public static class PropertyChangedNotificationInterceptor
    {
        static bool _suppressPropertyChanged;

        public static void Intercept(object target, Action onPropertyChangedAction, string propertyName)
        {
            // 🔥 SOLUZIONE AGGIUNTIVA: ignora le proprietà che non cambiano davvero
            if (string.IsNullOrWhiteSpace(propertyName))
                return;

            var navPage = Maui2BlazorApp.NavigationPage;
            if (navPage == null)
                return;

            var contentPage = navPage.CurrentContentPage;
            if (contentPage == null)
                return;

            if (GetIsPropertyChangedSuppressed())
            {
                DisableIsPropertyChangedSuppressed();
                return;
            }


            if (target is INotifyPropertyChangedExtended notifyPropertyChanged)
            {
                notifyPropertyChanged.OnPropertyChanged(target, propertyName);
            }


            if (target is BindableObject bindable)
            {
                DebugHelpers.WriteLine("RELOAD UI Object -> " + propertyName + " -> " + target);
                bindable.InvokeStateHasChanged();
            }
            else
            {
                DebugHelpers.WriteLine("RELOAD PAGE -> " + propertyName + " -> " + target);
                contentPage.InvokeSafeStateHasChanged();
            }
        }

        public static bool GetIsPropertyChangedSuppressed() => _suppressPropertyChanged;

        public static void EnableIsPropertyChangedSuppressed()
        {
            _suppressPropertyChanged = true;
        }

        public static void DisableIsPropertyChangedSuppressed()
        {
            _suppressPropertyChanged = false;
        }
    }
}

