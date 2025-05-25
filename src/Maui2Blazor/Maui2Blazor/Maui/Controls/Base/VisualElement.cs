using System.Windows.Input;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class VisualElement : NavigableElement
    {
        /// <summary>
        /// Colore di sfondo dell'elemento (in formato CSS, es. "red", "#FF0000").
        /// </summary>
        [Parameter]
        public string BackgroundColor { get; set; } = "transparent";

        /// <summary>
        /// Indica se l'elemento è visibile.
        /// </summary>
        [Parameter]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Indica se l'elemento è abilitato.
        /// </summary>
        [Parameter]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Opacità dell'elemento (da 0.0 a 1.0).
        /// </summary>
        [Parameter]
        public double Opacity { get; set; } = 1.0;

        /// <summary>
        /// Larghezza desiderata dell'elemento.
        /// </summary>
        [Parameter]
        public double WidthRequest { get; set; } = -1;

        /// <summary>
        /// Altezza desiderata dell'elemento.
        /// </summary>
        [Parameter]
        public double HeightRequest { get; set; } = -1;

        /// <summary>
        /// Larghezza minima richiesta.
        /// </summary>
        [Parameter]
        public double MinimumWidthRequest { get; set; } = -1;

        /// <summary>
        /// Altezza minima richiesta.
        /// </summary>
        [Parameter]
        public double MinimumHeightRequest { get; set; } = -1;

        /// <summary>
        /// Larghezza massima richiesta.
        /// </summary>
        [Parameter]
        public double MaximumWidthRequest { get; set; } = -1;

        /// <summary>
        /// Altezza massima richiesta.
        /// </summary>
        [Parameter]
        public double MaximumHeightRequest { get; set; } = -1;

        /// <summary>
        /// Sposta l'elemento lungo l'asse X.
        /// </summary>
        [Parameter]
        public double TranslationX { get; set; } = 0;

        /// <summary>
        /// Sposta l'elemento lungo l'asse Y.
        /// </summary>
        [Parameter]
        public double TranslationY { get; set; } = 0;

        /// <summary>
        /// Ruota l'elemento (in gradi).
        /// </summary>
        [Parameter]
        public double Rotation { get; set; } = 0;

        /// <summary>
        /// Ruota l'elemento lungo l'asse X.
        /// </summary>
        [Parameter]
        public double RotationX { get; set; } = 0;

        /// <summary>
        /// Ruota l'elemento lungo l'asse Y.
        /// </summary>
        [Parameter]
        public double RotationY { get; set; } = 0;

        /// <summary>
        /// Scala l'elemento uniformemente.
        /// </summary>
        [Parameter]
        public double Scale { get; set; } = 1.0;

        /// <summary>
        /// Scala l'elemento lungo l'asse X.
        /// </summary>
        [Parameter]
        public double ScaleX { get; set; } = 1.0;

        /// <summary>
        /// Scala l'elemento lungo l'asse Y.
        /// </summary>
        [Parameter]
        public double ScaleY { get; set; } = 1.0;


        // <summary>
        /// Comando MVVM eseguito quando si clicca il pulsante.
        /// </summary>
        [Parameter]
        public ICommand Command { get; set; }

        /// <summary>
        /// Parametro passato al comando.
        /// </summary>
        [Parameter]
        public object CommandParameter { get; set; }

        /// <summary>
        /// Evento per il clic singolo.
        /// </summary>
        [Parameter]
        public EventCallback OnClick { get; set; }

        /// <summary>
        /// Gestisce il click sul pulsante, eseguendo il comando o l'evento.
        /// </summary>
        public async Task OnClickHandler()
        {
            if (IsEnabled)
            {
                if (Command?.CanExecute(CommandParameter) == true)
                {
                    Command.Execute(CommandParameter);
                }
                else
                {
                    await OnClick.InvokeAsync();
                }
            }
        }


        /// <summary>
        /// Contenuto figlio dell'elemento.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Combina tutte le proprietà in uno stile CSS.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var visibility = IsVisible ? "display: block;" : "display: none;";
            var background = !string.IsNullOrWhiteSpace(BackgroundColor) ? $"background-color: {BackgroundColor};" : "";
            var opacity = $"opacity: {Opacity};";
            var translation = $"transform: translate({TranslationX}px, {TranslationY}px) rotate({Rotation}deg) scale({Scale});";

            //Size
            var widthRequest = "auto";
            if (WidthRequest > -1)
                widthRequest = $"{WidthRequest}px";

            var heightRequest = "auto";
            if (HeightRequest > -1)
                heightRequest = $"{HeightRequest}px";

            var size = $"width: {widthRequest}; height: {heightRequest};";

            //Min
            var minimumWidthRequest = "auto";
            if (MinimumWidthRequest > -1)
                minimumWidthRequest = $"{MinimumWidthRequest}px";

            var minimumHeightRequest = "auto";
            if (MinimumHeightRequest > -1)
                minimumHeightRequest = $"{MinimumHeightRequest}px";

            var minSize = $"min-width: {minimumWidthRequest}; min-height: {minimumHeightRequest};";

            //Max
            var maximumWidthRequest = "auto";
            if (MaximumWidthRequest > -1)
                maximumWidthRequest = $"{MaximumWidthRequest}px";

            var maximumHeightRequest = "auto";
            if (MaximumHeightRequest > -1)
                maximumHeightRequest = $"{MaximumHeightRequest}px";

            var maxSize = $"max-width: {maximumWidthRequest}; max-height: {maximumHeightRequest};";


            //
            var borderRadius = $"border-radius: {ScaleX}px;"; // Esempio per simulare il "border radius" dinamico.

            return $"{background} {visibility} {opacity} {translation} {size} {minSize} {maxSize} {borderRadius}".Trim();
        }
    }

}

