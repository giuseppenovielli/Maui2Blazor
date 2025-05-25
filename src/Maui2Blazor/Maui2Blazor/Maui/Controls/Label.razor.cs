using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Label : View
    {
        /// <summary>
        /// Testo visualizzato nella Label.
        /// </summary>
        [Parameter]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Attributi del font (Bold, Italic, None).
        /// </summary>
        [Parameter]
        public FontAttributes FontAttributes { get; set; } = FontAttributes.None;

        /// <summary>
        /// Nome del font da usare (es. "Arial", "FontAwesomeSolid").
        /// </summary>
        [Parameter]
        public string FontFamily { get; set; } = string.Empty;


        /// <summary>
        /// Allineamento orizzontale del testo (Left, Center, Right).
        /// </summary>
        [Parameter]
        public TextAlignment HorizontalTextAlignment { get; set; } = TextAlignment.Left;

        /// <summary>
        /// Allineamento verticale del testo (Top, Center, Bottom).
        /// </summary>
        [Parameter]
        public TextAlignment VerticalTextAlignment { get; set; } = TextAlignment.Top;

        /// <summary>
        /// Imposta la modalità di interruzione di riga (Truncate, Wrap, NoWrap, ecc.).
        /// </summary>
        [Parameter]
        public LineBreakMode LineBreakMode { get; set; } = LineBreakMode.NoWrap;

        /// <summary>
        /// Numero massimo di righe prima della troncatura.
        /// </summary>
        [Parameter]
        public int MaxLines { get; set; } = int.MaxValue;

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
        /// Combina lo stile di base con le proprietà specifiche della Label.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            if (FontAttributes.HasFlag(FontAttributes.Bold))
                style += " font-weight: bold;";

            if (FontAttributes.HasFlag(FontAttributes.Italic))
                style += " font-style: italic;";

            style += $" text-align: {HorizontalTextAlignment.ToString().ToLower()};";
            style += $" vertical-align: {VerticalTextAlignment.ToString().ToLower()};";

            if (!string.IsNullOrWhiteSpace(TextColor))
                style += $" color: {TextColor};";

            if (FontSize > 0)
                style += $" font-size: {FontSize}px;";

            if (!string.IsNullOrWhiteSpace(FontFamily))
                style += $" font-family: '{FontFamily}';";

            return style.Trim();
        }
    }

    [Flags]
    public enum FontAttributes
    {
        None = 0,
        Bold = 1,
        Italic = 2
    }

    public enum TextAlignment
    {
        Left,
        Center,
        Right,
        Top,
        Bottom
    }

    public enum LineBreakMode
    {
        NoWrap,
        WordWrap,
        CharacterWrap,
        HeadTruncation,
        TailTruncation,
        MiddleTruncation
    }



}

