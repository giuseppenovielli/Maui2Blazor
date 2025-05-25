namespace Maui2Blazor.Maui.Extensions
{
    using Microsoft.AspNetCore.Components;

    public static class GridExtensions
    {
        /// <summary>
        /// Indica la riga in cui posizionare l'elemento.
        /// </summary>
        [Parameter]
        public static int GridRow { get; set; } = 0;

        /// <summary>
        /// Indica la colonna in cui posizionare l'elemento.
        /// </summary>
        [Parameter]
        public static int GridColumn { get; set; } = 0;

        /// <summary>
        /// Indica il numero di righe che l'elemento deve occupare.
        /// </summary>
        [Parameter]
        public static int GridRowSpan { get; set; } = 1;

        /// <summary>
        /// Indica il numero di colonne che l'elemento deve occupare.
        /// </summary>
        [Parameter]
        public static int GridColumnSpan { get; set; } = 1;

        /// <summary>
        /// Restituisce lo stile CSS per posizionare un elemento nella Grid.
        /// </summary>
        public static string GetGridPositionStyle(int row, int col, int rowSpan, int colSpan)
        {
            return $"grid-row: {row + 1} / span {rowSpan}; grid-column: {col + 1} / span {colSpan};";
        }
    }

}

