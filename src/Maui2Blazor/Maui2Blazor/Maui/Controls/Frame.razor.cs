using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Frame : ContentView
    {
        [Parameter]
        public double CornerRadius { get; set; }

        [Parameter]
        public string BorderColor { get; set; }

        [Parameter]
        public bool HasShadow { get; set; }


        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            return style += $@"
                border-radius: {CornerRadius}px;
                border: 1px solid {BorderColor};
                background-color: {BackgroundColor};
                box-shadow: {(HasShadow ? "2px 2px 10px rgba(0,0,0,0.2)" : "none")};
            ";
        }
    }
}
