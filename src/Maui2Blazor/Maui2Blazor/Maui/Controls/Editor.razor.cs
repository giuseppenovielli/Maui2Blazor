using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Editor : InputView
    {
        /// <summary>
        /// Testo segnaposto quando l'Editor è vuoto.
        /// </summary>
        [Parameter] public string Placeholder { get; set; } = "Inserisci testo...";

        /// <summary>
        /// Colore del testo segnaposto.
        /// </summary>
        [Parameter] public string PlaceholderColor { get; set; } = "#888";

        /// <summary>
        /// Tipo di tastiera.
        /// </summary>
        [Parameter] public string Keyboard { get; set; } = "text"; // Default, Numeric, Email, Chat, etc.

        /// <summary>
        /// Se l'editor deve adattare l'altezza automaticamente al contenuto.
        /// </summary>
        [Parameter] public AutoSizeOption AutoSize { get; set; } = AutoSizeOption.None;


        /// <summary>
        /// Genera lo stile CSS dell'Editor.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();
            var autoSizeStyle = AutoSize == AutoSizeOption.TextChanges ? "height: auto; overflow: hidden;" : "";

            return style += autoSizeStyle;
        }
    }

    public enum AutoSizeOption
    {
        None,
        TextChanges
    }


}

