using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class StackBase : Layout
	{
        /// <summary>
        /// Spazio (in pixel) da applicare tra i figli.
        /// </summary>
        [Parameter]
        public double Spacing { get; set; } = 0;

        /// <summary>
        /// Sovrascrive il CombinedStyle per includere display flex, direzione, gap e padding.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            var gap = Spacing > 0 ? $" gap: {Spacing}px;" : "";

            style += $"{gap};";
            style += $@"
                align-items: {HorizontalOptions};
                justify-content: {VerticalOptions};";

            return style;
        }
    }

    public enum StackOrientation
    {
        Vertical,
        Horizontal
    }
}

