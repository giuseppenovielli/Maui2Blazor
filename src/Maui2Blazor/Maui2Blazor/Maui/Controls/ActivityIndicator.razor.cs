using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class ActivityIndicator : View
    {
        /// <summary>
        /// Indica se l'indicatore è in esecuzione.
        /// </summary>
        [Parameter]
        public bool IsRunning { get; set; } = false;

        /// <summary>
        /// Colore del loader (es. "red", "#FF0000").
        /// </summary>
        [Parameter]
        public string Color { get; set; } = "orange";

        /// <summary>
        /// Calcola lo stile inline.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            var color = $"color: {Color};";
            var animation = IsRunning ? "" : "display: none;";
            return $"{color} {animation}".Trim();
        }
    }
}
