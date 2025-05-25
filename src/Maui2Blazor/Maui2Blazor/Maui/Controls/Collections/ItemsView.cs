using System.Collections;
using System.Windows.Input;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class ItemsView : Layout
    {
        // **DATI PRINCIPALI**
        [Parameter] public IEnumerable ItemsSource { get; set; } = Array.Empty<object>();
        [Parameter] public RenderFragment<object> ItemTemplate { get; set; }

        // **LAYOUT**
        [Parameter] public ItemsLayout Orientation { get; set; } = ItemsLayout.Vertical;

        // **INFINITE SCROLL**
        [Parameter] public int RemainingItemsThreshold { get; set; } = 5;
        [Parameter] public ICommand RemainingItemsThresholdReachedCommand { get; set; }

        /// <summary>
        /// Evento chiamato quando l'utente scorre fino alla fine della lista.
        /// </summary>
        [Parameter] public EventCallback OnScrolledToEnd { get; set; }

        /// <summary>
        /// Restituisce il template corretto per un elemento.
        /// </summary>
        protected virtual RenderFragment<object> GetItemTemplate(object item) => ItemTemplate;

        /// <summary>
        /// Metodo per attivare l'evento di scroll infinito.
        /// </summary>
        protected async Task HandleScrollAsync()
        {
            if (RemainingItemsThresholdReachedCommand != null && RemainingItemsThresholdReachedCommand.CanExecute(null))
            {
                RemainingItemsThresholdReachedCommand.Execute(null);
            }

            await OnScrolledToEnd.InvokeAsync();
        }

        /// <summary>
        /// Metodo per ottenere lo stile CSS del layout in base all'orientamento.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = Style;

            style += Orientation == ItemsLayout.Vertical
                ? "display: flex; flex-direction: column; overflow-y: auto; height: 100%;"
                : "display: flex; flex-direction: row; overflow-x: auto;";

            return style;
        }
            
    }



    public enum SelectionMode
    {
        None,
        Single,
        Multiple
    }

    public enum ItemsLayout
    {
        Vertical,
        Horizontal
    }

}

