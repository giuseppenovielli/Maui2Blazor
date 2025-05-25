using System.Windows.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class InputView : View
    {
        /// <summary>
        /// Testo contenuto nell'InputView.
        /// </summary>
        [Parameter] public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Numero massimo di caratteri permessi.
        /// </summary>
        [Parameter] public int MaxLength { get; set; } = int.MaxValue;

        /// <summary>
        /// Evento chiamato quando il testo cambia.
        /// </summary>
        [Parameter] public EventCallback<string> TextChanged { get; set; }

        /// <summary>
        /// Evento chiamato quando si preme Invio.
        /// </summary>
        [Parameter] public EventCallback<string> Completed { get; set; }

        /// <summary>
        /// Evento chiamato quando l'input riceve il focus.
        /// </summary>
        [Parameter] public EventCallback OnFocus { get; set; }

        /// <summary>
        /// Evento chiamato quando l'input perde il focus.
        /// </summary>
        [Parameter] public EventCallback OnBlur { get; set; }

        /// <summary>
        /// Evento chiamato quando viene premuto un tasto.
        /// </summary>
        [Parameter] public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

        /// <summary>
        /// Comando per pulire il testo dell'input.
        /// </summary>
        [Parameter] public ICommand ClearTextCommand { get; set; }

        protected override void OnInitialized()
        {
            if (ClearTextCommand == null)
            {
                ClearTextCommand = new Command(() => Text = string.Empty);
            }
        }

        /// <summary>
        /// Metodo chiamato quando cambia il testo.
        /// </summary>
        protected async Task HandleTextChanged(ChangeEventArgs e)
        {
            Text = e?.Value.ToString();
            await TextChanged.InvokeAsync(Text);
        }

        /// <summary>
        /// Metodo chiamato quando si preme Invio.
        /// </summary>
        protected async Task HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await Completed.InvokeAsync(Text);
            }
        }

        /// <summary>
        /// Metodo chiamato quando l'input riceve il focus.
        /// </summary>
        protected async Task HandleFocus()
        {
            await OnFocus.InvokeAsync();
        }

        /// <summary>
        /// Metodo chiamato quando l'input perde il focus.
        /// </summary>
        protected async Task HandleBlur()
        {
            await OnBlur.InvokeAsync();
        }
    }

}

