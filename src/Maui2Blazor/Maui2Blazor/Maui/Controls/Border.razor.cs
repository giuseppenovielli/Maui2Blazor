using Maui2Blazor.Maui.Graphics;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Border : View
    {
        /// <summary>
        /// Colore del bordo (es. "red", "#FF0000").
        /// </summary>
        [Parameter]
        public string Stroke { get; set; } = "black";

        /// <summary>
        /// Spessore del bordo in pixel.
        /// </summary>
        [Parameter]
        public string StrokeThickness { get; set; } = "1";

        /// <summary>
        /// Raggio dell’angolo (es. "0", "10px", "50%").
        /// </summary>
        [Parameter]
        public string StrokeShape { get; set; } // Simula CornerRadius

        /// <summary>
        /// Colore di sfondo del contenitore.
        /// </summary>
        [Parameter]
        public string Background { get; set; } = "transparent";

        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            style += $"border: {StrokeThickness}px;" +
                    $"solid {Stroke}; " +
                     $"background-color: {Background};";

            if (!string.IsNullOrWhiteSpace(StrokeShape))
                style += $" border-radius: {new CornerRadius(StrokeShape)};";

            return style.Trim();
        }
    }
}
