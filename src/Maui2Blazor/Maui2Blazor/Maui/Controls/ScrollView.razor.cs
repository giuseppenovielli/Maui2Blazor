using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Maui2Blazor.Maui.Controls
{
    public partial class ScrollView : Layout
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// ID univoco per identificare il componente nella pagina.
        /// </summary>
        private string ElementId { get; } = $"scrollview-{Guid.NewGuid()}";

        /// <summary>
        /// Orientamento dello scroll: Verticale, Orizzontale o Entrambi.
        /// </summary>
        [Parameter] public ScrollOrientation Orientation { get; set; } = ScrollOrientation.Vertical;

        /// <summary>
        /// Evento chiamato quando l'utente scorre.
        /// </summary>
        [Parameter] public EventCallback<ScrollEventArgs> OnScrolled { get; set; }

        /// <summary>
        /// Genera lo stile CSS per la `ScrollView`.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            var overflowX = Orientation == ScrollOrientation.Horizontal || Orientation == ScrollOrientation.Both ? "auto" : "hidden";
            var overflowY = Orientation == ScrollOrientation.Vertical || Orientation == ScrollOrientation.Both ? "auto" : "hidden";

            return style += $"overflow-x: {overflowX}; overflow-y: {overflowY}; width: 100%; height: 100%;";
        }

        /// <summary>
        /// Metodo chiamato quando la `ScrollView` viene scrollata.
        /// </summary>
        private async Task HandleScroll(EventArgs e)
        {
            var scrollArgs = new ScrollEventArgs(); // Aggiungi i dettagli dell'evento se necessari
            await OnScrolled.InvokeAsync(scrollArgs);
        }

        /// <summary>
        /// Metodo per scrollare a una posizione specifica.
        /// </summary>
        public async Task ScrollToAsync(int x, int y, bool animated = true)
        {
            await JSRuntime.InvokeVoidAsync("scrollViewInterop.scrollTo", ElementId, x, y, animated);
        }
    }

    public enum ScrollOrientation
    {
        Vertical,
        Horizontal,
        Both
    }

    public class ScrollEventArgs : EventArgs
    {
        public double ScrollX { get; set; }
        public double ScrollY { get; set; }
    }


}

