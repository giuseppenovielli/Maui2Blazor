using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Maui2Blazor.Maui.Controls
{
    public partial class CarouselView : ItemsView
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// ID univoco per l'elemento nel DOM.
        /// </summary>
        private string ElementId { get; } = $"carousel-{Guid.NewGuid()}";

        /// <summary>
        /// L'elemento attualmente visualizzato.
        /// </summary>
        [Parameter] public object CurrentItem { get; set; }

        /// <summary>
        /// Indice dell'elemento attualmente visualizzato.
        /// </summary>
        [Parameter] public int Position { get; set; } = 0;

        /// <summary>
        /// Evento chiamato quando cambia la posizione.
        /// </summary>
        [Parameter] public EventCallback<int> PositionChanged { get; set; }

        /// <summary>
        /// Se abilitato, scorre ciclicamente gli elementi.
        /// </summary>
        [Parameter] public bool Loop { get; set; } = false;

        /// <summary>
        /// Mostra parzialmente gli elementi adiacenti.
        /// </summary>
        [Parameter] public int PeekAreaInsets { get; set; } = 0;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("carouselInterop.initializeCarousel", ElementId);
            }
        }

        public async Task ScrollToAsync(int index, bool animated = true)
        {
            if (index < 0 || index >= ItemsSource.Cast<object>().Count())
            {
                return;
            }

            Position = index;
            CurrentItem = ItemsSource.Cast<object>().ElementAt(index);
            await PositionChanged.InvokeAsync(Position);

            await JSRuntime.InvokeVoidAsync("carouselInterop.scrollTo", ElementId, index, animated);
        }

        /// <summary>
        /// Metodo chiamato quando cambia la posizione dell'elemento attuale.
        /// </summary>
        private async Task HandleScroll()
        {
            var count = ItemsSource.Cast<object>().Count();
            if (Position >= count - 1 && Loop)
            {
                await ScrollToAsync(0);
            }
        }

        /// <summary>
        /// Genera lo stile CSS per la `CarouselView`.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            return $"overflow-x: {(Orientation == ItemsLayout.Horizontal ? "auto" : "hidden")}; " +
                   $"overflow-y: {(Orientation == ItemsLayout.Vertical ? "auto" : "hidden")}; " +
                   $"scroll-snap-type: {(Orientation == ItemsLayout.Horizontal ? "x mandatory" : "y mandatory")};";
        }
    }
}

