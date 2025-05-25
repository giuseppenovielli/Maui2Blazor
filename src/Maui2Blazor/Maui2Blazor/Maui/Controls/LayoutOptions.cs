namespace Maui2Blazor.Maui.Controls
{
    public class LayoutOptions
    {
        public string CssValue { get; }

        private LayoutOptions(string cssValue)
        {
            CssValue = cssValue;
        }

        public static LayoutOptions Start => new LayoutOptions("flex-start");
        public static LayoutOptions Center => new LayoutOptions("center");
        public static LayoutOptions End => new LayoutOptions("flex-end");
        public static LayoutOptions Fill => new LayoutOptions("stretch");

        public override string ToString() => CssValue;
    }
}

