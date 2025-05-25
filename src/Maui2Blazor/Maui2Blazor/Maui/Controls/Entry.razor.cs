using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Windows.Input;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Entry : InputView
    {
        /// <summary>
        /// Placeholder per il campo di input.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; } = string.Empty;

        /// <summary>
        /// Se true, il campo viene mostrato come password.
        /// </summary>
        [Parameter]
        public bool IsPassword { get; set; } = false;

        /// <summary>
        /// Specifica la tastiera da utilizzare.
        /// </summary>
        [Parameter]
        public string Keyboard { get; set; } = "text"; // "text", "email", "number", "tel", "url"

        /// <summary>
        /// Comando per MVVM quando l'utente preme Invio.
        /// </summary>
        [Parameter]
        public ICommand CompletedCommand { get; set; }

        /// <summary>
        /// Gestisce il cambiamento del testo.
        /// </summary>
        public async Task HandleTextChanged(ChangeEventArgs e)
        {
            Text = e.Value.ToString();
            await TextChanged.InvokeAsync(Text);
        }

        /// <summary>
        /// Gestisce il completamento quando viene premuto Invio.
        /// </summary>
        public async Task HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await Completed.InvokeAsync(Text);

                if (CompletedCommand != null && CompletedCommand.CanExecute(Text))
                {
                    CompletedCommand.Execute(Text);
                }
            }
        }


        /// <summary>
        /// Restituisce lo stile CSS dinamico per l'Entry.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            return style += $"width: 100%; padding: 8px; border: 1px solid #ccc; border-radius: 4px;";

        }

        /// <summary>
        /// Determina il tipo di input corretto.
        /// </summary>
        private string InputType => IsPassword ? "password" : Keyboard switch
        {
            "email" => "email",
            "number" => "number",
            "tel" => "tel",
            "url" => "url",
            _ => "text"
        };
    }

}

