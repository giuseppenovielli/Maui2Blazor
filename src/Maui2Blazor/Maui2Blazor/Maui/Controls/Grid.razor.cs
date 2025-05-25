using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Grid : Layout
    {
        /// <summary>
        /// Definizione delle righe (es. "Auto, Auto").
        /// </summary>
        [Parameter]
        public string RowDefinitions { get; set; } = "*";

        /// <summary>
        /// Definizione delle colonne (es. "*").
        /// </summary>
        [Parameter]
        public string ColumnDefinitions { get; set; } = "*";


        /// <summary>
        /// Spaziatura tra le righe, in pixel (es. "10px").
        /// </summary>
        [Parameter] public string RowSpacing { get; set; } = "0";

        /// <summary>
        /// Spaziatura tra le colonne, in pixel (es. "10px").
        /// </summary>
        [Parameter] public string ColumnSpacing { get; set; } = "0";


        /// <summary>
        /// Converte le definizioni in uno stile CSS per grid.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            style += $"display: grid;";
            style += $"grid-template-rows: {ParseDefinitions(RowDefinitions)};";
            style += $"grid-template-columns: {ParseDefinitions(ColumnDefinitions)};";
            style += $"row-gap: {RowSpacing}px;";
            style += $"column-gap: {ColumnSpacing}px;";

            return style;
        }


        /// <summary>
        /// Converte una stringa di definizioni in un formato compatibile con CSS Grid.
        /// </summary>
        private static string ParseDefinitions(string definitions)
        {
            return string.Join(" ", definitions.Split(',')
                .Select(def => def.Trim() switch
                {
                    "*" => "1fr",
                    "Auto" => "auto",
                    _ => def.EndsWith("*") ? $"{def.TrimEnd('*')}fr" : $"{def}px"
                }));
        }
    }

}

