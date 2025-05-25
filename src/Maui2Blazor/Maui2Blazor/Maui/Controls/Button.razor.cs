using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Button : View
    {
        /// <summary>
        /// Testo del pulsante.
        /// </summary>
        [Parameter]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Attributi del font (Bold, Italic, None).
        /// </summary>
        [Parameter]
        public FontAttributes FontAttributes { get; set; } = FontAttributes.None;


        /// <summary>
        /// Bordo arrotondato del pulsante.
        /// </summary>
        [Parameter]
        public string CornerRadius { get; set; } = "5px";

        /// <summary>
        /// Colore del bordo.
        /// </summary>
        [Parameter]
        public string BorderColor { get; set; } = "#007BFF";

        /// <summary>
        /// Spessore del bordo.
        /// </summary>
        [Parameter]
        public string BorderWidth { get; set; } = "1px";

        /// <summary>
        /// Colore del testo.
        /// </summary>
        [Parameter]
        public string TextColor { get; set; } = "black";


        /// <summary>
        /// Dimensione del carattere.
        /// </summary>
        [Parameter]
        public double FontSize { get; set; } = 16;

        /// <summary>
        /// Combina lo stile base con le proprietà specifiche del pulsante.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            if (FontAttributes.HasFlag(FontAttributes.Bold))
                style += " font-weight: bold;";

            if (FontAttributes.HasFlag(FontAttributes.Italic))
                style += " font-style: italic;";

            if (!string.IsNullOrWhiteSpace(BorderColor))
                style += $" border: {BorderWidth} solid {BorderColor};";

            if (!string.IsNullOrWhiteSpace(CornerRadius))
                style += $" border-radius: {CornerRadius};";

            if (!string.IsNullOrWhiteSpace(TextColor))
                style += $" color: {TextColor};";

            if (FontSize > 0)
                style += $" font-size: {FontSize}px;";

            return style;
        }
    }

}

