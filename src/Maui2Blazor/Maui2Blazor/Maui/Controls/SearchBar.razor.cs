using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
namespace Maui2Blazor.Maui.Controls
{
    public partial class SearchBar : InputView
    {
        /// <summary>
        /// Placeholder del campo di ricerca.
        /// </summary>
        [Parameter] public string Placeholder { get; set; } = "Cerca...";

        /// <summary>
        /// Evento chiamato quando il testo cambia.
        /// </summary>
        [Parameter] public EventCallback<string> OnTextChanged { get; set; }

        /// <summary>
        /// Evento chiamato quando viene premuto il pulsante di ricerca.
        /// </summary>
        [Parameter] public EventCallback<string> OnSearchButtonPressed { get; set; }

        /// <summary>
        /// Esegue il refresh automatico quando il testo cambia.
        /// </summary>
        private async Task HandleTextChanged(ChangeEventArgs e)
        {
            Text = e.Value.ToString();
            await OnTextChanged.InvokeAsync(Text);
        }

        /// <summary>
        /// Rileva la pressione del tasto Invio per avviare la ricerca.
        /// </summary>
        private async Task HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await TriggerSearch();
            }
        }

        /// <summary>
        /// Avvia la ricerca manualmente.
        /// </summary>
        private async Task TriggerSearch()
        {
            await OnSearchButtonPressed.InvokeAsync(Text);
        }
    }

}

