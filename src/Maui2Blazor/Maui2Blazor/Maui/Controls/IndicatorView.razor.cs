using System.Collections;
using Maui2Blazor.Maui.Controls;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class IndicatorView : TemplatedView
    {
        /// <summary>
        /// Elenco di elementi per cui gli indicatori sono generati.
        /// </summary>
        [Parameter] public IEnumerable ItemsSource { get; set; }

        /// <summary>
        /// Numero totale di indicatori.
        /// </summary>
        public int Count => ItemsSource?.Cast<object>().Count() ?? 0;

        /// <summary>
        /// Indice attuale dell'elemento attivo.
        /// </summary>
        [Parameter] public int Position { get; set; } = 0;

        /// <summary>
        /// Evento chiamato quando cambia la posizione.
        /// </summary>
        [Parameter] public EventCallback<int> PositionChanged { get; set; }

        /// <summary>
        /// Colore predefinito degli indicatori.
        /// </summary>
        [Parameter] public string IndicatorColor { get; set; } = "#CCCCCC";

        /// <summary>
        /// Colore dell'indicatore attivo.
        /// </summary>
        [Parameter] public string SelectedIndicatorColor { get; set; } = "#007BFF";

        /// <summary>
        /// Dimensione degli indicatori.
        /// </summary>
        [Parameter] public string IndicatorSize { get; set; } = "12px";

        /// <summary>
        /// Imposta la posizione attuale dell'indicatore.
        /// </summary>
        public async Task SetPosition(int position)
        {
            if (position >= 0 && position < Count)
            {
                Position = position;
                await PositionChanged.InvokeAsync(Position);
                StateHasChanged();
            }
        }

        /// <summary>
        /// Metodo chiamato quando un indicatore viene cliccato.
        /// </summary>
        private async Task ChangePosition(int newPosition)
        {
            await SetPosition(newPosition);
        }
    }

}

