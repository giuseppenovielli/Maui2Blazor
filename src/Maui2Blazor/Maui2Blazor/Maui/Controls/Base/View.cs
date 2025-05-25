using Maui2Blazor.Maui.Graphics;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class View : VisualElement
    {
        /// <summary>
        /// Margine, in formato stringa (es. "10px" o "10px 20px 10px 20px").
        /// </summary>
        [Parameter]
        public string Margin { get; set; } = string.Empty;

        /// <summary>
        /// Padding, in formato stringa (es. "10px" o "10px 20px").
        /// </summary>
        [Parameter]
        public string Padding { get; set; } = string.Empty;

        /// <summary>
        /// Opzioni orizzontali (Start, Center, End, Fill).
        /// </summary>
        [Parameter]
        public LayoutOptions HorizontalOptions { get; set; } = LayoutOptions.Fill;

        /// <summary>
        /// Opzioni verticali (Start, Center, End, Fill).
        /// </summary>
        [Parameter]
        public LayoutOptions VerticalOptions { get; set; } = LayoutOptions.Fill;

        /// <summary>
        /// Indice Z dell'elemento, utile per controllare la sovrapposizione.
        /// </summary>
        [Parameter]
        public int ZIndex { get; set; } = 0;

        /// <summary>
        /// Clip per ritagliare i contenuti.
        /// </summary>
        [Parameter]
        public string Clip { get; set; } = string.Empty;

        /// <summary>
        /// Ombra applicata all'elemento.
        /// </summary>
        [Parameter]
        public string Shadow { get; set; } = string.Empty;

        /// <summary>
        /// Evento per il doppio clic.
        /// </summary>
        [Parameter]
        public EventCallback OnDoubleClick { get; set; }

        /// <summary>
        /// Evento per il long press (simulato con onmousedown + timeout).
        /// </summary>
        [Parameter]
        public EventCallback OnLongPress { get; set; }

        /// <summary>
        /// Collezione di GestureRecognizers per gestire tap, swipe, pinch, ecc.
        /// </summary>
        public GestureRecognizerContainer GestureRecognizerContainer { get; set; } = new();

        /// <summary>
        /// Indica se l'elemento è attualmente focalizzato.
        /// </summary>
        [Parameter]
        public bool IsFocused { get; set; } = false;

        /// <summary>
        /// Evento sollevato quando l'elemento riceve il focus.
        /// </summary>
        [Parameter]
        public EventCallback OnFocused { get; set; }

        /// <summary>
        /// Evento sollevato quando l'elemento perde il focus.
        /// </summary>
        [Parameter]
        public EventCallback OnUnfocused { get; set; }

        /// <summary>
        /// Identificatore per l'accessibilità (AutomationId).
        /// </summary>
        [Parameter]
        public string AutomationId { get; set; } = string.Empty;

        /// <summary>
        /// Indica se il campo è di sola lettura.
        /// </summary>
        [Parameter]
        public bool IsReadOnly { get; set; } = false;

        /// <summary>
        /// Calcola lo stile combinato includendo le proprietà extra.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            if (!string.IsNullOrWhiteSpace(Margin))
                style += $" margin: {Margin};";

            if (!string.IsNullOrWhiteSpace(Padding))
                style += $" padding: {Padding};";

            if (!string.IsNullOrWhiteSpace(Shadow))
                style += $" box-shadow: {Shadow};";

            if (!string.IsNullOrWhiteSpace(Clip))
                style += $" clip-path: {Clip}; overflow: hidden;";

            if (ZIndex != 0)
                style += $" z-index: {ZIndex};";

            if (HorizontalOptions != null)
                style += $" align-self: {HorizontalOptions};";

            if (VerticalOptions != null)
                style += $" justify-self: {VerticalOptions};";

            return style.Trim();
        }

        /// <summary>
        /// Gestisce il click singolo: invoca l'evento OnClick e notifica tutti i TapGestureRecognizer.
        /// </summary>
        public async Task HandleClickAsync()
        {
            if (OnClick.HasDelegate)
                await OnClick.InvokeAsync(null);

            // Notifica i GestureRecognizers se sono tap.
            if (GestureRecognizerContainer != null)
            {
                GestureRecognizerContainer.TriggerTapRecognizers();
            }
        }

        /// <summary>
        /// Gestisce il doppio click: invoca l'evento OnDoubleClick e notifica i gesture riconoscitori se necessario.
        /// </summary>
        public async Task HandleDoubleClickAsync()
        {
            if (OnDoubleClick.HasDelegate)
                await OnDoubleClick.InvokeAsync(null);

            // Potresti aggiungere una logica simile per eventuali riconoscitori di double-tap.
        }

        /// <summary>
        /// Gestisce il long press: invoca l'evento OnLongPress e notifica i gesture riconoscitori se necessario.
        /// </summary>
        public async Task HandleLongPressAsync()
        {
            if (OnLongPress.HasDelegate)
                await OnLongPress.InvokeAsync(null);

            // Puoi aggiungere ulteriori logiche se intendi supportare long press nei gesture recognizers.
        }
    }

}

