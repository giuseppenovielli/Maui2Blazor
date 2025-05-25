namespace Maui2Blazor.Maui.Graphics
{
    public struct Thickness
    {
        public double Left { get; }
        public double Top { get; }
        public double Right { get; }
        public double Bottom { get; }

        public Thickness(string size)
        {
            if (string.IsNullOrWhiteSpace(size) || size.Contains("px")) return;


            var marginThickness = size.Split(",");
            if (marginThickness.Length == 4)
            {
                Left = Convert.ToDouble(marginThickness[0]);
                Top = Convert.ToDouble(marginThickness[1]);
                Right = Convert.ToDouble(marginThickness[2]);
                Bottom = Convert.ToDouble(marginThickness[3]);
            }
            else
            {
                var sizeDouble = Convert.ToDouble(size);

                Left = sizeDouble;
                Top = sizeDouble;
                Right = sizeDouble;
                Bottom = sizeDouble;
            }
        }

        public Thickness(double uniformSize)
        {
            Left = Top = Right = Bottom = uniformSize;
        }

        public Thickness(double horizontal, double vertical)
        {
            Left = Right = horizontal;
            Top = Bottom = vertical;
        }

        public Thickness(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public override string ToString() => $"{Top}px {Right}px {Bottom}px {Left}px";

        public static string GetCss(double left, double top, double right, double bottom)
        {
            var size = $"{left},{top},{right},{bottom}";
            var t = new Thickness(size);
            return t.ToString();
            
        }

        public static string GetUniformCss(double uniformSize)
        {
            return GetCss(uniformSize, uniformSize, uniformSize, uniformSize);
        }
    }
}
