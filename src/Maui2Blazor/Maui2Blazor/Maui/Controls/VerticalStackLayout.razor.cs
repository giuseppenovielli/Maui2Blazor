using Maui2Blazor.Maui.Controls;

namespace Maui2Blazor.Maui.Controls
{
    public partial class VerticalStackLayout : StackBase
    {
        /// <summary>
        /// Sovrascrive il CombinedStyle per includere display flex, direzione, gap e padding.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            style += $"display: flex; flex-direction: column;";
            return style;
        }
    }
}

