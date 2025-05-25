using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Maui2Blazor.Maui.Controls
{
    public partial class WebView : View
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        private ElementReference iframeElement;

        /// <summary>
        /// Indirizzo web attuale del WebView.
        /// </summary>
        [Parameter] public string Source { get; set; }

        /// <summary>
        /// Evento chiamato prima della navigazione.
        /// </summary>
        [Parameter] public EventCallback<string> Navigating { get; set; }

        /// <summary>
        /// Evento chiamato dopo la navigazione.
        /// </summary>
        [Parameter] public EventCallback<string> Navigated { get; set; }

        /// <summary>
        /// Ricarica la pagina attuale.
        /// </summary>
        public async Task Refresh()
        {
            await JSRuntime.InvokeVoidAsync("eval", $"document.getElementById('{iframeElement.Id}').contentWindow.location.reload()");
        }

        /// <summary>
        /// Torna indietro nella cronologia.
        /// </summary>
        public async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("eval", $"document.getElementById('{iframeElement.Id}').contentWindow.history.back()");
        }

        /// <summary>
        /// Va avanti nella cronologia.
        /// </summary>
        public async Task GoForward()
        {
            await JSRuntime.InvokeVoidAsync("eval", $"document.getElementById('{iframeElement.Id}').contentWindow.history.forward()");
        }

        /// <summary>
        /// Notifica quando la navigazione è completata.
        /// </summary>
        private async Task HandleNavigated()
        {
            await Navigated.InvokeAsync(Source);
        }
    }

}

