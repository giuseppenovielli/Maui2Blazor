using System.ComponentModel;
using Maui2Blazor.Maui.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class BindableObject : ComponentBase, INotifyPropertyChangedExtended, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _isRendered;

        public BindableObject()
        {
        }

        /// <summary>
        /// La proprietà BindingContext, come in .NET MAUI.
        /// </summary>
        [Parameter]
        public object BindingContext { get; set; }


        /// <summary>
        /// Viene invocato quando il BindingContext cambia; può essere overridato.
        /// </summary>
        protected virtual void OnBindingContextChanged()
        {
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                _isRendered = true;

                // Se non è stato impostato esplicitamente, usa il valore cascaded
                // per gli elementi come CollectionView (altrimenti va imposstato manualmente)
                if (BindingContext != null)
                    return;

                var currentPage = Maui2BlazorApp.NavigationPage?.CurrentContentPage;
                if (currentPage == null)
                    return;

                BindingContext = currentPage.BindingContext;
            }
                
        }


        /// <summary>
        /// Notifica che una proprietà è cambiata.
        /// </summary>
        public void OnPropertyChanged(object sender, string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            OnBindingContextChanged();
        }

        public void InvokeStateHasChanged()
        {
            if (_isRendered)
                InvokeAsync(StateHasChanged);
        }

        public virtual void Dispose()
        {
        }
    }

}

