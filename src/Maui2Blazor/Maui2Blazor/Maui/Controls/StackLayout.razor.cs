using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class StackLayout : StackBase
    {
        /// <summary>
        /// Specifica l'orientamento dei figli: Vertical (default) o Horizontal.
        /// </summary>
        [Parameter]
        public StackOrientation Orientation { get; set; } = StackOrientation.Vertical;

        /// <summary>
        /// Sovrascrive il CombinedStyle per includere display flex, direzione, gap e padding.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            var flexDirection = Orientation == StackOrientation.Vertical ? "column" : "row";

            style += $"display: flex; flex-direction: {flexDirection};";
            return style;
        }
    }
}

