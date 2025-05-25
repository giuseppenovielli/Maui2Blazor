namespace Maui2Blazor.Maui.Graphics
{
    public struct Color
    {
        public string CssColor { get; }

        private Color(string cssColor)
        {
            CssColor = cssColor;
        }

        public static Color FromHex(string hex) => new Color(hex);

        public static Color Black => new Color("#000000");
        public static Color White => new Color("#FFFFFF");
        public static Color Transparent => new Color("transparent");
        public static Color Red => new Color("#FF0000");
        public static Color Green => new Color("#00FF00");
        public static Color Blue => new Color("#0000FF");
        public static Color Yellow => new Color("#FFFF00");
        public static Color Gray => new Color("#808080");

        public override string ToString() => CssColor;
    }
}
